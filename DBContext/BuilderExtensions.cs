using Microsoft.EntityFrameworkCore;
using newsroom.Model;

namespace newsroom.DBContext
{
    public static class BuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Theme>().HasData(
                new Theme { Id = 1, name = "sport", imageUrl = "https://images.unsplash.com/photo-1483721310020-03333e577078?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=80" },
                new Theme { Id = 2, name = "Lifestyle", imageUrl = "https://images.unsplash.com/photo-1546548970-71785318a17b?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=400&q=60" }
            );

           


            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, name = "Pierre Edimo", imageUrl = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=700&q=60", biography = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr," }
              
                );


            modelBuilder.Entity<Article>().HasData(
              new Article
              {
                  Id = 1 ,
                  authorId = 1, 
                  imageUrl= "https://images.unsplash.com/photo-1575017159701-e94c1fa4386c?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&auto=format&fit=crop&w=564&q=80",
                  title="My first text, the beginning of my journey as a writer", 
                  themeId = 2,
                  content = "**2020 has been a difficult year , both mentaly and financialy, but as it is nearing its end, i have decided to share my experience to the world**\n" +

                            "my name is Pierre Patrice Emmanuel Edimo Nkoe , i study Computer Science in Germany , where i live since the last 8 years. I came here i was 18 years old\n" +
                            "from Cameroon. It has been a humbling experience for me. There were good moments , there were bas moments , i learn a lot from this Country. It is an experience\n" +
                            "i want to share with people all around the world.\n" +
                            "i look forward to share more of my experience and my Interest with have a nice day , and a nice fun reading my articles\n" +

                            " for interested you can [contact me](pedimonkoe@yahoo.com) "

              }
            );


        }
    }
}