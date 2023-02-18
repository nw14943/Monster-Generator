// This is a top-level statement.
// It is essentially the main function.
Console.WriteLine("Program Start");

// This should display an empty monster
Monster m1 = new Monster();
m1.display();
m1.display(false);
Console.WriteLine(m1);
Console.WriteLine();

// This should display a monster with 15 in all stats
Monster m2 = new Monster("Monster");
m2.display();
m2.display(false);
Console.WriteLine(m2);
Console.WriteLine();

// This should display the stat block for an Adult Red Dragon
Monster m3 = new Monster("Adult Red Dragon");
m3.display();
m3.display(false);
Console.WriteLine(m2);
Console.WriteLine();

Console.WriteLine("Program End");

// Stores the name and stat block of a monster
class Monster
{
    // Create an empty monster.
    public Monster()
    {
        this.name = "Unnamed";
        this.statBlock = new StatBlock();
    }
    // Create a new monster based on its name.
    public Monster(string name)
    {
        this.name = name;
        this.statBlock = new StatBlock(name);
    }
    // This changes what is displayed when a conversion to string is requested.
    public override string ToString()
    {
        return $"{this.name}";
    }
    // Because this is private, it can't be accessed outside of the class.
    // The name of the monster.
    private string name;
    // Classes can be member variables.
    // The statBlock of the monster.
    public StatBlock statBlock;

    // Returns the name of the monster.
    public string getName()
    {
        return this.name;
    }
    // This displays the monster's statBlock.
    // If limit is true, only the limited statBlock is displayed
    // If no value is passed, limit is true.
    public void display(bool limit = true)
    {
        Console.WriteLine(this);
        this.statBlock.display(limit);
    }
}
class StatBlock
{
    // Creates an empty statBlock
    public StatBlock()
    {
        setByName("");
    }
    // Gets the statBlock of a named monter if found.
    public StatBlock(string name)
    {
        setByName(name);
    }
    // Override of the conversion to string.
    public override string ToString()
    {
        return 
            $"  CR: {this.cr}\n" +
            $"  Type: {this.size} {this.type}\n" +
            $"  Alignment: {this.alignment}";
    }

    // Chalenge Rating, this describes how strong the monster is.
    private int cr;
    // Size is how big the monster is.
    // This is an enumeration. Only specific values are accepted here.
    private Size size;
    // What type of monster this is.
    private string type;
    // How the monster will act.
    // This is an enumeration. Only specific values are accepted here.
    private Alignment alignment;
    // Armor Class, how hard is it to deal damage to.
    private int ac;
    // Hit Points, how much damage can it take before dying.
    private int hp;
    // The six main stats for DnD
    // This is a class
    private Stats stats;
    // Display the stats for this monster.
    // Console.WriteLine calls the toString function
    // If limit is false, the full statBlock will be displayed.
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
    // Gets the stats of the monster by its name.
    // If no name is found, an empty statBlock is created.
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

// The six main stats in DnD
class Stats 
{
    // Empty stats are 0
    public Stats()
    {
        this.strength     = 0;
        this.dexerity     = 0;
        this.constitution = 0;
        this.intelegence  = 0;
        this.wisdom       = 0;
        this.charisma     = 0;
    }
    // Initialize to the same value.
    public Stats(int value)
    {
        this.strength     = value;
        this.dexerity     = value;
        this.constitution = value;
        this.intelegence  = value;
        this.wisdom       = value;
        this.charisma     = value;
    }
    // Unique values for each stat.
    public Stats(int s, int d, int c, int i, int w, int ch)
    {
        this.strength     = s;
        this.dexerity     = d;
        this.constitution = c;
        this.intelegence  = i;
        this.wisdom       = w;
        this.charisma     = ch;
    }
    // Override of the conversion to string
    public override string ToString()
    {
        return 
        $"  STR:{this.strength} DEX:{this.dexerity} CON:{this.constitution}\n" +
    $"      INT:{this.intelegence} WIS:{this.wisdom} CHA:{this.charisma}";
    }
    // How physically strong is it.
    private int strength;
    // How agile is it.
    private int dexerity;
    // How tough is it (health and endurance)
    private int constitution;
    // How book smart is it
    private int intelegence;
    // How street smart is it
    private int wisdom;
    // How well does it do with social iteractions
    private int charisma;
}

// How big is it. Empty is none
enum Size {None, Small, Tiny, Medium, Large, Huge, Gargantuan, Titan}
// How does it act. Empty is none
enum Alignment {None, CG, NG, LG, CN, NN, LN, CE, NE, LE}