using Microsoft.EntityFrameworkCore;
using newsroom.Model;

namespace newsroom.DBContext
{
    public static class BuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name =" Pierre Edimo "
                }
            );

            modelBuilder.Entity<Topic>().HasData(
                new Topic
                {
                    Id = 1,
                    Name = "Sport",
                    ImageUrl = "https://images.unsplash.com/photo-1483721310020-03333e577078?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1400&q=80"
                },

                new Topic
                {
                    Id = 2,
                    Name = "Tech/It",
                    ImageUrl = "https://images.unsplash.com/photo-1518770660439-4636190af475?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"
                },

                new Topic
                {
                    Id = 3,
                    Name = "Health",
                    ImageUrl = "https://images.unsplash.com/photo-1532938911079-1b06ac7ceec7?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1489&q=80"
                },
                new Topic
                {
                    Id = 4,
                    Name = "Entertainment",
                    ImageUrl = "https://images.unsplash.com/photo-1470076892663-af684e5e15af?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1217&q=80"
                },
                new Topic
                {
                    Id = 5,
                    Name = "Business",
                    ImageUrl = "https://images.unsplash.com/photo-1454165804606-c3d57bc86b40?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"
                },
                new Topic
                {
                    Id = 6,
                    Name = "Lifestyle",
                    ImageUrl = "https://images.unsplash.com/photo-1501747315-124a0eaca060?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80"
                },
                new Topic
                {
                    Id = 7,
                    Name = "Religion",
                    ImageUrl = "https://images.unsplash.com/photo-1520187044487-b2efb58f0cba?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80", 
                },
                new Topic
                {
                    Id = 8,
                    Name = "Travel",
                    ImageUrl = "https://images.unsplash.com/photo-1476900543704-4312b78632f8?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80"
                },
                new Topic
                {
                    Id = 9, 
                    Name = "Science", 
                    ImageUrl = "https://images.unsplash.com/photo-1564325724739-bae0bd08762c?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"
                }, 
                new Topic
                {
                    Id = 10, 
                    Name ="Politic", 
                    ImageUrl = "https://images.unsplash.com/photo-1535903021127-d50417eae4a3?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"
                }


            );

            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    AuthorId = 1 , 
                    ImageUrl = "https://images.unsplash.com/photo-1587620962725-abab7fe55159?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1489&q=80", 
                    ImageCredits ="www.unsplash.com",
                    TopicId = 2, 
                    Title = "Getting started with Programming", 
                    Content = "**Programming is a very hard and demanding task. I dont# t want "+
                              "to say i am some sort expert or anything like that , but i have"+
                              "been learning programming since 2 years and i want to share my experience so far**"+
                              "\n"+
                              "\n" +
                              "\n" +
                              "At first glance, you should know that the market for electric cars is growing " +
                              "thanks to the aid proposed by the European Union, but due to the crisis caused by" +
                              " Covid, the traditional German brands are facing a huge crisis. In addition to " +
                              "facing their production bases, they have to invest even more capital to electrify " +
                              "their fleets. The result ? Mercedes Benz, for example, has launched a vast savings " +
                              "programme, which consists in cutting unnecessary expenses, delocalising the production " +
                              "of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked " +
                              "more than 10,000 employees in 2020, and it's not over yet. "+
                              "\n" +
                              "\n" +
                              "\n" +
                              "It is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are " +
                              "facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. " +
                              "While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric " +
                              "cars produced by vw have been a huge success in Europe."+
                              "\n" +
                              "\n" +
                              "\n" +
                              "Now let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an" +
                              " entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it" +
                              " is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is " +
                              "the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable " +
                              "business. But that can change very quickly."+
                              "\n" +
                              "\n" +
                              "\n" +
                              "In conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid."

                },
                  new Article
                  {
                      Id = 2,
                      AuthorId = 1,
                      ImageUrl = "https://images.unsplash.com/photo-1571987502227-9231b837d92a?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=700&q=80",
                      ImageCredits = "www.unsplash.com",
                      TopicId = 2,
                      Title = "Tesla is the highest publicly valuated car manufacturer, what does it mean for Germany",
                      Content = "**At the end of 2019, everyone announced Tesla's death. But today" +
                              "Tesla is more valuable than Volswagen, Daimler and Toyota put " +
                              "together, I'll explain why and what it means for German brands.**" +
                              "\n" +
                              "\n" +
                              "\n" +
                              "At first glance, you should know that the market for electric cars is growing " +
                              "thanks to the aid proposed by the European Union, but due to the crisis caused by" +
                              " Covid, the traditional German brands are facing a huge crisis. In addition to " +
                              "facing their production bases, they have to invest even more capital to electrify " +
                              "their fleets. The result ? Mercedes Benz, for example, has launched a vast savings " +
                              "programme, which consists in cutting unnecessary expenses, delocalising the production " +
                              "of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked " +
                              "more than 10,000 employees in 2020, and it's not over yet. " +
                              "\n" +
                              "\n" +
                              "\n" +
                              "It is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are " +
                              "facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. " +
                              "While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric " +
                              "cars produced by vw have been a huge success in Europe." +
                              "\n" +
                              "\n" +
                              "\n" +
                              "Now let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an" +
                              " entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it" +
                              " is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is " +
                              "the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable " +
                              "business. But that can change very quickly." +
                              "\n" +
                              "\n" +
                              "\n" +
                              "In conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid."

                  },

                  new Article
                  {
                      Id = 3,
                      AuthorId = 1,
                      ImageUrl = "https://images.unsplash.com/photo-1545693315-85b6be26a3d6?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80",
                      ImageCredits = "www.unsplash.com",
                      TopicId = 9,
                      Title = "Genders aren't social constructs",
                      Content = "**At the end of 2019, everyone announced Tesla's death. But today" +
                              "Tesla is more valuable than Volswagen, Daimler and Toyota put " +
                              "together, I'll explain why and what it means for German brands.**" +
                              "\n" +
                              "\n" +
                              "\n" +
                              "At first glance, you should know that the market for electric cars is growing " +
                              "thanks to the aid proposed by the European Union, but due to the crisis caused by" +
                              " Covid, the traditional German brands are facing a huge crisis. In addition to " +
                              "facing their production bases, they have to invest even more capital to electrify " +
                              "their fleets. The result ? Mercedes Benz, for example, has launched a vast savings " +
                              "programme, which consists in cutting unnecessary expenses, delocalising the production " +
                              "of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked " +
                              "more than 10,000 employees in 2020, and it's not over yet. " +
                              "\n" +
                              "\n" +
                              "\n" +
                              "It is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are " +
                              "facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. " +
                              "While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric " +
                              "cars produced by vw have been a huge success in Europe." +
                              "\n" +
                              "\n" +
                              "\n" +
                              "Now let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an" +
                              " entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it" +
                              " is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is " +
                              "the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable " +
                              "business. But that can change very quickly." +
                              "\n" +
                              "\n" +
                              "\n" +
                              "In conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid."

                  },
                  new Article
                  {
                      Id = 4,
                      AuthorId = 1,
                      ImageUrl = "https://images.unsplash.com/photo-1528629297340-d1d466945dc5?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=922&q=80",
                      ImageCredits = "www.unsplash.com",
                      TopicId = 1,
                      Title = "Biking is healthy",
                      Content = "**At the end of 2019, everyone announced Tesla's death. But today" +
                              "Tesla is more valuable than Volswagen, Daimler and Toyota put " +
                              "together, I'll explain why and what it means for German brands.**" +
                              "\n" +
                              "\n" +
                              "\n" +
                              "At first glance, you should know that the market for electric cars is growing " +
                              "thanks to the aid proposed by the European Union, but due to the crisis caused by" +
                              " Covid, the traditional German brands are facing a huge crisis. In addition to " +
                              "facing their production bases, they have to invest even more capital to electrify " +
                              "their fleets. The result ? Mercedes Benz, for example, has launched a vast savings " +
                              "programme, which consists in cutting unnecessary expenses, delocalising the production " +
                              "of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked " +
                              "more than 10,000 employees in 2020, and it's not over yet. " +
                              "\n" +
                              "\n" +
                              "\n" +
                              "It is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are " +
                              "facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. " +
                              "While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric " +
                              "cars produced by vw have been a huge success in Europe." +
                              "\n" +
                              "\n" +
                              "\n" +
                              "Now let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an" +
                              " entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it" +
                              " is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is " +
                              "the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable " +
                              "business. But that can change very quickly." +
                              "\n" +
                              "\n" +
                              "\n" +
                              "In conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid."

                  }
             );  
        }
    }
}