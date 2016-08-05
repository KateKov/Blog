using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogKovalenko.DAL.Entities;
using BlogKovalenko.DAL.ViewModels;


namespace BlogKovalenko.DAL.EF
{
    public class ArticleDbInitializer : DropCreateDatabaseAlways<ArticleContext>
    {
        protected override void Seed(ArticleContext db)
        {
            var authors = new List<Author> {
            new Author() { Name = "Андрей", Surname = "Васильев", AuthorId = 1 },
            new Author() { Name = "Валентин", Surname = "Романов", AuthorId = 2 } };
        

            authors.ForEach(s => db.Authors.Add(s));
            db.SaveChanges();

            Tag tag1 = new Tag { TagId = 1, Title = " It " };
            Tag tag2 = new Tag { TagId = 2, Title = " C# " };
            Tag tag3 = new Tag { TagId = 3, Title = " JavaScript " };
            Tag tag4 = new Tag { TagId = 4, Title = " CSS " };

            db.Tags.Add(tag1);
            db.Tags.Add(tag2);
            db.Tags.Add(tag3);
            db.Tags.Add(tag4);
            db.SaveChanges();

            var articles = new List<Article> {
            new Article { ArticleId = 1, Photo="../../Content/tpscr.jpg",   Tags=new List<Tag>() { tag1, tag3}, AuthorId=1, Title="TypeScript", Date = DateTime.Parse("2016-07-07"), Text = "TypeScript — компилируемое надмножество языка JavaScript со статической типизацией и фичами из новейших стандартов ES 6 & ES 7. Это значит, что при разработке вы можете в полной мерой воспользоваться красотой и пользой строгой типизации, а потом скомпилировать это в обычный браузерный JavaScript и использовать его на продакте без потери совместимости с браузерами. Рекомендуется использовать (и на Западе уже используется) во всех новых проектах сложнее выпадающего меню и украденного с CodePen прелоадера — например, новая версия Angular от Google написана именно на TypeScript. В качестве альтернатив — чистые ES 6 & ES 7 с последующей компиляцией в ES 5 через babel. Но на самом деле не стоит бояться TypeScript — за ним стоит такая крупная корпорация, как Microsoft, которая вряд ли бросит всё на произвол." },
            new Article { ArticleId = 2, Photo="../../Content/sass.jpg", Tags=new List<Tag>() {tag1, tag4 }, AuthorId=2, Title="SASS", Date = DateTime.Parse("2016-12-07"), Text = "Написание CSS само по себе весело, но когда таблица стилей становится огромной, то становится и сложно её обслуживать. И вот в таком случае нам поможет препроцессор. SASS — Syntactically Awesome Style Sheets, или <<CSS с суперсилой>> и, в частности, вариант синтаксиса SCSS, позволяет использовать функции, недоступные в самом CSS, например, переменные, вложенности, миксины, наследование и другие приятные вещи, возвращающие удобство написания CSS. Как только Вы начинаете пользоваться SASS, препроцессор компилирует ваш SASS-файл и сохраняет его как простой CSS-файл, который вы можете использовать как обычно." },
            new Article { ArticleId = 3, Photo="../../Content/ns.jpg",   Tags=new List<Tag>() { tag1}, AuthorId=1, Title="Нейронные сети", Date = DateTime.Parse("2016-07-25"), Text = " Искусственные нейронные сети применяются в различных областях науки: начиная от систем распознавания речи до распознавания вторичной структуры белка, классификации различных видов рака и генной инженерии. Однако как они работает изнутри и как начать их использовать самому? Предлагаем поставить себе цель на лето — узнать ответ на эти вопросы и создать свою собственною нейронку." },
            new Article { ArticleId = 4, Photo="../../Content/rust.png",   Tags=new List<Tag>() { tag1}, AuthorId=2, Title="Rust", Date = DateTime.Parse("2016-07-25"), Text = " Rust — это язык программирования общего назначения от компании Mozilla, разрабатываемый с 2010-го года. Разработчики Rust ставят перед собой задачу, с одной стороны, достичь производительности C/C++ (все же понимают, DSL’ем для разработки какого браузера является Rust?), а с другой — умудриться сделать язык высокоуровневым и безопасным. Как минимум, это будет весомая ачивка в вашем резюме, как максимум — вы станете одним из первых экспертов на растущем рынке." },
            new Article { ArticleId = 5, Photo="../../Content/react.png",   Tags=new List<Tag>() { tag1}, AuthorId=1, Title="React", Date = DateTime.Parse("2016-07-26"), Text = " Разработанная в Facebook технология была выпущена не так давно и в этом году всё чаще и чаще выбирается для разработки крупных веб, Android и iOS приложений. React.js часто используют в связке с TypeScript. Кстати, разработка приложений для мобильных устройств — ещё одна возможная цель и потенциальное достижение за лето. В таком случае вам понадобятся языки Java и Swift — начать кодить на них реально даже за месяц." } };
            articles.ForEach(s => db.Articles.Add(s));
            db.SaveChanges();

            var variants = new List<Variant>()
            {
               new Variant() { VariantId = 1, Text = "TypeScript", Vote = 17, },
               new Variant() { VariantId = 2, Text = "SASS", Vote = 25 },
            new Variant() { VariantId = 3, Text = "Нейронные сети", Vote = 10 },
            new Variant() { VariantId = 4, Text = "Rust", Vote = 15 },
            new Variant() { VariantId = 5, Text = "React", Vote = 23 }};
            variants.ForEach(s => db.Variants.Add(s));
            db.SaveChanges();

            int sumofvote = 0;
            variants.ForEach(s => sumofvote += s.Vote);
            var poll = new Poll() { PollId = 1, Title = "Какая из статей понравилась Вам больше всего?", Sum = sumofvote, Variants = variants };
            db.Polls.Add(poll);
            db.SaveChanges();

            db.Reviews.Add(new Review { Person = "Антон", Date = new DateTime(2016, 07, 15, 20, 12, 15), Text = "Интересно почитать" });
            db.Reviews.Add(new Review { Person = "Мария", Date = new DateTime(2016, 07, 15, 21, 14, 17), Text = "Нужно больше развиваться. Не хватает навыков в создании сайта" });
            db.Reviews.Add(new Review { Person = "Денис", Date = new DateTime(2016, 07, 16, 8, 46, 26), Text = "Я как раз осваиваю React" });
            db.SaveChanges();

        }
    }
}
