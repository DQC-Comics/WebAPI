namespace DQC.Comics.WebAPI.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ComicsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ComicsDbContext context)
        {
            context.Heroes.AddOrUpdate(
              p => p.Name,
              new Hero { Name = "Spider-Man", Description = "Bitten by a radioactive spider, high school student Peter Parker gained the speed, strength and powers of a spider. Adopting the name Spider-Man, Peter hoped to start a career using his new abilities. Taught that with great power comes great responsibility, Spidey has vowed to use his powers to help people.", Color = "Red", ImageUrl = "https://i.annihil.us/u/prod/marvel/i/mg/9/30/538cd33e15ab7/standard_xlarge.jpg", DebitPrice = 2000, InternalPrice = 1500 },
              new Hero { Name = "Hulk", Description = "Caught in a gamma bomb explosion while trying to save the life of a teenager, Dr. Bruce Banner was transformed into the incredibly powerful creature called the Hulk. An all too often misunderstood hero, the angrier the Hulk gets, the stronger the Hulk gets", Color = "Green", ImageUrl = "http://i.annihil.us/u/prod/marvel/i/mg/5/a0/538615ca33ab0/standard_xlarge.jpg", DebitPrice = 2500, InternalPrice = 2100 },
              new Hero { Name = "Thor", Description = "As the Norse God of thunder and lightning, Thor wields one of the greatest weapons ever made, the enchanted hammer Mjolnir. While others have described Thor as an over-muscled, oafish imbecile, he's quite smart and compassionate. He's self-assured, and he would never, ever stop fighting for a worthwhile cause.", Color = "Black", ImageUrl = "https://i.annihil.us/u/prod/marvel/i/mg/5/a0/537bc7036ab02/standard_xlarge.jpg", DebitPrice = 2100, InternalPrice = 1400 }, 
              new Hero { Name = "Iron Man", Description = "Wounded, captured and forced to build a weapon by his enemies, billionaire industrialist Tony Stark instead created an advanced suit of armor to save his life and escape captivity. Now with a new outlook on life, Tony uses his money and intelligence to make the world a safer, better place as Iron Man.", Color = "Red", ImageUrl = "https://i.annihil.us/u/prod/marvel/i/mg/6/a0/55b6a25e654e6/standard_xlarge.jpg", DebitPrice = 4000, InternalPrice = 3000 },
              new Hero { Name = "Luke Cage", Description = "Born and raised in Harlem, Carl Lucas spent his youth in a gang called the Bloods. With his friend Willis Stryker, he fought the rival gang the Diablos and committed petty thefts, often on behalf of deformed crimelord Sonny Caputo, a.k.a. Hammer.", Color = "Brown", ImageUrl = "http://x.annihil.us/u/prod/marvel/i/mg/5/e0/537bb460046bd/standard_xlarge.jpg", DebitPrice = 1700, InternalPrice = 1100 }, 
              new Hero { Name = "Black Widow", Description = "Natasha Romanova, known by many aliases, is an expert spy, athlete, and assassin. Trained at a young age by the KGB's infamous Red Room Academy, the Black Widow was formerly an enemy to the Avengers. She later became their ally after breaking out of the U.S.S.R.'s grasp, and also serves as a top S.H.I.E.L.D. agent.", Color = "Blue", ImageUrl = "http://x.annihil.us/u/prod/marvel/i/mg/9/10/537ba3f27a6e0/standard_xlarge.jpg", DebitPrice = 2000, InternalPrice = 1300 },
              new Hero { Name = "Daredevil", Description = "Abandoned by his mother, Matt Murdock was raised by his father, boxer \"Battling Jack\" Murdock, in Hell's Kitchen. Realizing that rules were needed to prevent people from behaving badly, young Matt decided to study law; however, when he saved a man from an oncoming truck, it spilled a radioactive cargo that rendered Matt blind while enhancing his remaining senses. Under the harsh tutelage of blind martial arts master Stick, Matt mastered his heightened senses and became a formidable fighter.", Color = "Red", ImageUrl = "http://i.annihil.us/u/prod/marvel/i/mg/6/90/537ba6d49472b/standard_xlarge.jpg", DebitPrice = 1900, InternalPrice = 1500 },
              new Hero { Name = "Captain America", Description = "Vowing to serve his country any way he could, young Steve Rogers took the super soldier serum to become America's one-man army. Fighting for the red, white and blue for over 60 years, Captain America is the living, breathing symbol of freedom and liberty.", Color = "Blue", ImageUrl = "http://i.annihil.us/u/prod/marvel/i/mg/3/50/537ba56d31087/standard_xlarge.jpg", DebitPrice = 1500, InternalPrice = 1000 }, 
              new Hero { Name = "Wolverine", Description = "Born with super-human senses and the power to heal from almost any wound, Wolverine was captured by a secret Canadian organization and given an unbreakable skeleton and claws. Treated like an animal, it took years for him to control himself. Now, he's a premiere member of both the X-Men and the Avengers.", Color = "Black", ImageUrl = "https://i.annihil.us/u/prod/marvel/i/mg/2/60/537bcaef0f6cf/standard_xlarge.jpg", DebitPrice = 1700, InternalPrice = 1100 }
            );
        }
    }
}
