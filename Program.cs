// This is a top-level statement.
// It is essentially the main function.
Console.WriteLine("Program Start");

Monster m1 = new Monster();
m1.display();
m1.display(false);
Console.WriteLine(m1);
Console.WriteLine();

Monster m2 = new Monster("Monster");
m2.display();
m2.display(false);
Console.WriteLine(m2);
Console.WriteLine();

Monster m3 = new Monster("Adult Red Dragon");
m3.display();
m3.display(false);
Console.WriteLine(m2);
Console.WriteLine();

Console.WriteLine("Program End");


class Monster
{
    public Monster()
    {
        this.name = "Unnamed";
        this.statBlock = new StatBlock();
    }
    public Monster(string name)
    {
        this.name = name;
        this.statBlock = new StatBlock(name);
    }
    public override string ToString()
    {
        return $"{this.name}";
    }
    private string name;
    public StatBlock statBlock;

    public string getName()
    {
        return this.name;
    }
    public void display(bool limit = true)
    {
        Console.WriteLine(this);
        this.statBlock.display(limit);
    }
}
class StatBlock
{
    public StatBlock()
    {
        setByName("");
    }
    public StatBlock(string name)
    {
        setByName(name);
    }
    public override string ToString()
    {
        return 
            $"  CR: {this.cr}\n" +
            $"  Type: {this.size} {this.type}\n" +
            $"  Alignment: {this.alignment}";
    }

    private int cr;
    private Size size;
    private string type;
    private Alignment alignment;
    private int ac;
    private int hp;
    private Stats stats;
    public void display(bool limit = true)
    {
        Console.WriteLine(this);
        if (!limit)
        {
            Console.WriteLine($"    AC: {this.ac}");
            Console.WriteLine($"    Hit Points: {this.hp}");
            Console.WriteLine($"    Stats:\n    {this.stats}");
        }
    }
    public void setByName(string name)
    {
        switch (name)
        {
        case "Monster":
            this.cr = 1;
            this.size = Size.Large;
            this.type = "Monstrosity";
            this.alignment = Alignment.NN;
            this.ac = 15;
            this.hp = 30;
            this.stats = new Stats(15);
            break;
        case "Adult Red Dragon":
            this.cr = 17;
            this.size = Size.Huge;
            this.type = "Dragon";
            this.alignment = Alignment.CE;
            this.ac = 19;
            this.hp = 256;
            this.stats = new Stats(27, 10, 25, 16, 13, 21);
            break;
        default:
            this.cr = -1;
            this.size = Size.None;
            this.type = "None";
            this.alignment = Alignment.None;
            this.ac = 0;
            this.hp = 0;
            this.stats = new Stats();
            break;
        }
    }
}

class Stats 
{
    public Stats()
    {
        this.strength     = 0;
        this.dexerity     = 0;
        this.constitution = 0;
        this.intelegence  = 0;
        this.wisdom       = 0;
        this.charisma     = 0;
    }
    public Stats(int value)
    {
        this.strength     = value;
        this.dexerity     = value;
        this.constitution = value;
        this.intelegence  = value;
        this.wisdom       = value;
        this.charisma     = value;
    }
    public Stats(int s, int d, int c, int i, int w, int ch)
    {
        this.strength     = s;
        this.dexerity     = d;
        this.constitution = c;
        this.intelegence  = i;
        this.wisdom       = w;
        this.charisma     = ch;
    }
    public override string ToString()
    {
        return 
        $"  STR:{this.strength} DEX:{this.dexerity} CON:{this.constitution}\n" +
    $"      INT:{this.intelegence} WIS:{this.wisdom} CHA:{this.charisma}";
    }
    private int strength;
    private int dexerity;
    private int constitution;
    private int intelegence;
    private int wisdom;
    private int charisma;
}

enum Size {None, Small, Tiny, Medium, Large, Huge, Gargantuan, Titan}
enum Alignment {None, CG, NG, LG, CN, NN, LN, CE, NE, LE}