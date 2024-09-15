public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public List<Skill> Skills { get; set; }

    public Character(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        Skills = new List<Skill>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public void AddSkill(Skill skill)
    {
        Skills.Add(skill);
    }

    public void UseSkill(int skillIndex, Character target)
    {
        if (skillIndex >= 0 && skillIndex < Skills.Count)
        {
            Skills[skillIndex].UseSkill(target);
        }
    }
}