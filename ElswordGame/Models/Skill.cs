public class Skill
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Skill(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public void UseSkill(Character target)
    {
        target.TakeDamage(Damage);
    }
}