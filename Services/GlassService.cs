using SeeSharp.Models;

namespace SeeSharp.Services;

public static class GlassService
{
    static List<Glass> Glass { get; }
    static int nextId = 3;
    static GlassService()
    {
        Glass = new List<Glass>
        {
            new Glass { Id = 1, Name = "Ray-Ban Clubmaster", Color = "Brown / Gold", Shape = "brownline" },
            new Glass { Id = 2, Name = "Ottoto Bellona", Color = "Pink / Gold", Shape = "Oval" },
             new Glass { Id = 3, Name = "Oakley Socket 5.5", Color = "Gunmetal", Shape = "Rectangle" },
        };
    }

    public static List<Glass> GetAll() => Glass;

    public static Glass? Get(int id) => Glass.FirstOrDefault(p => p.Id == id);

    public static void Add(Glass glass)
    {
        glass.Id = nextId++;
        Glass.Add(glass);
    }

    public static void Delete(int id)
    {
        var glass = Get(id);
        if(glass is null)
            return;

        Glass.Remove(glass);
    }

    public static void Update(Glass glass)
    {
        var index = Glass.FindIndex(p => p.Id == glass.Id);
        if(index == -1)
            return;

        Glass[index] = glass;
    }
}