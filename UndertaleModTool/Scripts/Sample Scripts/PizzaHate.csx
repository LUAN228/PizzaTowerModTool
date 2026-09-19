using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

EnsureDataLoaded();

// Configuração da Seed (permite número ou "random")
string seedInput = SimpleTextInput("Seed", "Digite um número de seed ou 'random' para aleatório:", "random", false);
int seedValue;
if (seedInput.Trim().ToLower() == "random" || !int.TryParse(seedInput, out seedValue))
{
    seedValue = new Random().Next(int.MinValue, int.MaxValue);
}

static Random rng;
rng = new Random(seedValue);

float randomPower = float.Parse(SimpleTextInput("Power", "Intensidade da aleatorização dos sprites (de 0 a 1, 1 é o máximo):", "0.6", false));

static void Shuffle<T>(this IList<T> list)
{
    int n = list.Count;
    while (n > 1)
    {
        n--;
        int k = rng.Next(n + 1);

        T value = list[k];
        list[k] = list[n];
        list[n] = value;
    }
}

static void ShuffleOnlySelected<T>(this IList<T> list, IList<int> selected, Action<int, int> swapFunc)
{
    int n = selected.Count;
    while (n > 1)
    {
        n--;
        int k = rng.Next(n + 1);

        swapFunc(selected[n], selected[k]);

        int idx = selected[k];
        selected[k] = selected[n];
        selected[n] = idx;
    }
}

static void ShuffleOnlySelected<T>(this IList<T> list, IList<int> selected)
{
    list.ShuffleOnlySelected(selected, (n, k) => 
    {
        T value = list[k];
        list[k] = list[n];
        list[n] = value;
    });
}

static void SelectSome(this IList<int> list, float amountToKeep)
{
    int toRemove = (int)(list.Count * (1 - amountToKeep));
    for (int i = 0; i < toRemove; i++)
        list.RemoveAt(rng.Next(list.Count));
}

// 1. Aleatorização de Sprites (ignorando sprites do jogador e fundos)
List<int> tiny = new List<int>();
List<int> small = new List<int>();
List<int> characterlike = new List<int>();
List<int> big = new List<int>();

for (int i = 0; i < Data.Sprites.Count; i++)
{
    var sprite = Data.Sprites[i];
    string sprName = sprite.Name.Content.ToLower();

    // Ignora backgrounds e qualquer sprite de jogador (Peppino, Noise, etc.)
    if (sprName.StartsWith("bg_") || sprName.StartsWith("bg") || sprName.StartsWith("spr_player"))
        continue;

    if (sprite.Width < 50 && sprite.Height < 50)
        tiny.Add(i);
    else if (sprite.Width < 50 && sprite.Height < 100)
        characterlike.Add(i);
    else if (sprite.Width < 100 && sprite.Height < 100)
        small.Add(i);
    else if (sprite.Width < 200 && sprite.Height < 200)
        big.Add(i);
}

tiny.SelectSome(randomPower);
small.SelectSome(randomPower);
characterlike.SelectSome(randomPower);
big.SelectSome(randomPower);

Data.Sprites.ShuffleOnlySelected(tiny);
Data.Sprites.ShuffleOnlySelected(small);
Data.Sprites.ShuffleOnlySelected(characterlike);
Data.Sprites.ShuffleOnlySelected(big);

// 2. Aleatorização de Sons
Data.Sounds.Shuffle();

// 3. Aleatorização de Fontes
List<int> fonts = new List<int>();
for (int i = 0; i < Data.Fonts.Count; i++)
{
    fonts.Add(i);
}
Data.Fonts.ShuffleOnlySelected(fonts);

// 4. Aleatorização de Strings/Textos
void StringSwap(int n, int k)
{
    string value = Data.Strings[k].Content;
    Data.Strings[k].Content = Data.Strings[n].Content;
    Data.Strings[n].Content = value;
}

List<int> textLines = new List<int>();
for (int i = 0; i < Data.Strings.Count; i++)
{
    var str = Data.Strings[i].Content;
    // Ignora textos muito curtos ou caracteres de código para evitar quebras
    if (str.Length <= 2 || str.Any(x => x > 127))
        continue;

    textLines.Add(i);
}
Data.Strings.ShuffleOnlySelected(textLines, StringSwap);

// 5. Atualização dos Objetos (Protegendo obj_player, obj_player1, obj_player2, obj_mainmenu)
string[] protectedObjects = new string[] { "obj_player", "obj_player1", "obj_player2", "obj_mainmenu" };

foreach (var obj in Data.GameObjects)
{
    if (obj is null || !obj.Visible)
        continue;

    string objName = obj.Name.Content.ToLower();

    // Se for um dos objetos protegidos, ignora
    if (protectedObjects.Contains(objName))
        continue;

    if (obj._sprite.CachedId >= 0)
        obj.Sprite = Data.Sprites[obj._sprite.CachedId];
    if (obj._textureMaskId.CachedId >= 0)
        obj.TextureMaskId = Data.Sprites[obj._textureMaskId.CachedId];
}

ScriptMessage($"* PIZZA TIME! *\n\nCorrupção concluída com sucesso!\nSeed utilizada: {seedValue}");
