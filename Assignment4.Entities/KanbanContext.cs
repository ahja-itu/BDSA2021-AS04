using Assignment4.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment4.Entities
{
    public class KanbanContext : DbContext
    {

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Task>()
                .Property(e => e.State)
                .HasConversion(new EnumToStringConverter<State>());
        }

        public static void Seed(KanbanContext context)
        {
            // Clear out the database
            context.Database.ExecuteSqlRaw("DELETE dbo.Tags");
            context.Database.ExecuteSqlRaw("DELETE dbo.Tasks");
            context.Database.ExecuteSqlRaw("DELETE dbo.TagTask");
            context.Database.ExecuteSqlRaw("DELETE dbo.Users");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('dbo.Tasks', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('dbo.Users', RESEED, 0)");


            // Seed with users
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Filberto', 'fsnaden0@linkedin.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Tito', 'tzmitrichenko1@ycombinator.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Alfie', 'ahubback2@i2i.jp');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Conrad', 'cmclae3@phpbb.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Suzi', 'sflude4@networksolutions.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Wenonah', 'wbeecheno5@yahoo.co.jp');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Matthias', 'mharfleet6@bbc.co.uk');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Leupold', 'lstenton7@newyorker.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Margot', 'mextence8@kickstarter.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Gavrielle', 'gstedall9@instagram.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Charlton', 'cacorsa@state.gov');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Carling', 'comahonyb@archive.org');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Pat', 'pbertomieuc@yolasite.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Ellynn', 'edonavand@shinystat.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Idalina', 'icorteze@livejournal.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Klara', 'kmarrowf@squidoo.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Zea', 'znewboldg@rambler.ru');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Angelique', 'adarkh@msn.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Lola', 'lflahyi@yahoo.co.jp');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Briana', 'btouretj@gmpg.org');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Sosanna', 'scurnowk@so-net.ne.jp');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Giorgio', 'gkenyonl@icio.us');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Shandra', 'sgaveym@rediff.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Nicholas', 'ngilfoylen@hostgator.com');");
            context.Database.ExecuteSqlRaw("insert into users (name, email) values ('Yale', 'ysuteo@4shared.com');");

            // Seed tasks
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('lobortis ligula sit amet eleifend pede', 13, 'bibendum felis sed interdum venenatis turpis enim blandit mi in porttitor pede justo eu massa donec dapibus duis at velit eu est congue elementum in hac habitasse platea dictumst morbi vestibulum velit id pretium iaculis diam erat fermentum justo nec condimentum neque sapien placerat ante nulla justo aliquam quis turpis eget elit sodales scelerisque mauris sit amet eros suspendisse accumsan tortor quis turpis sed ante vivamus tortor duis mattis egestas metus', 'Closed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('sagittis nam congue risus semper porta volutpat quam pede', 1, 'risus semper porta volutpat quam pede lobortis ligula sit amet eleifend pede libero quis orci nullam molestie nibh in lectus pellentesque at nulla suspendisse potenti cras in purus eu magna vulputate luctus cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus vivamus vestibulum sagittis', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('morbi a ipsum integer', 23, 'leo rhoncus sed vestibulum sit amet cursus id turpis integer aliquet massa id lobortis convallis tortor risus dapibus augue vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero nullam sit amet turpis elementum ligula vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor id nulla ultrices aliquet maecenas leo odio condimentum id luctus nec molestie sed justo pellentesque viverra pede ac diam cras pellentesque volutpat', 'Active');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('vulputate justo in blandit ultrices enim lorem ipsum dolor', 23, 'euismod scelerisque quam turpis adipiscing lorem vitae mattis nibh ligula nec sem duis aliquam convallis nunc proin at turpis a pede posuere nonummy integer non velit donec diam neque vestibulum eget vulputate ut ultrices vel augue vestibulum ante ipsum primis in faucibus orci luctus et', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('vulputate justo in blandit ultrices enim', 25, 'lectus in est risus auctor sed tristique in tempus sit amet sem fusce consequat nulla nisl nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit mi in porttitor pede justo eu massa donec dapibus duis at velit eu est congue elementum in hac habitasse platea dictumst morbi vestibulum velit id pretium iaculis diam erat fermentum justo nec condimentum neque sapien placerat ante nulla justo aliquam quis turpis eget', 'Active');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('consectetuer eget rutrum at lorem integer', 10, 'metus aenean fermentum donec ut mauris eget massa tempor convallis nulla neque libero convallis eget eleifend luctus ultricies eu nibh quisque id justo sit amet sapien dignissim vestibulum vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae nulla dapibus dolor vel est donec odio justo sollicitudin ut suscipit a feugiat et eros vestibulum ac est', 'Active');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('iaculis justo in hac habitasse', 25, 'ipsum dolor sit amet consectetuer adipiscing elit proin interdum mauris non ligula pellentesque ultrices phasellus id sapien in sapien iaculis congue vivamus metus arcu adipiscing molestie hendrerit at vulputate vitae nisl aenean lectus pellentesque eget nunc donec quis orci eget orci vehicula condimentum curabitur in libero ut massa volutpat convallis morbi odio odio elementum eu interdum eu tincidunt in leo maecenas pulvinar lobortis est phasellus sit', 'Resolved');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('ligula in lacus curabitur at ipsum ac', 4, 'primis in faucibus orci luctus et ultrices posuere cubilia curae nulla dapibus dolor vel est donec odio justo sollicitudin ut suscipit a feugiat et eros vestibulum ac est lacinia nisi venenatis tristique fusce congue diam id ornare imperdiet sapien urna pretium nisl ut volutpat sapien arcu sed augue aliquam erat volutpat in congue etiam justo etiam pretium iaculis justo in hac habitasse platea dictumst etiam faucibus cursus urna ut tellus nulla ut erat id mauris vulputate', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('condimentum curabitur in libero', 9, 'ac est lacinia nisi venenatis tristique fusce congue diam id ornare imperdiet sapien urna pretium nisl ut volutpat sapien arcu sed augue aliquam erat volutpat in congue etiam justo etiam pretium iaculis justo in hac habitasse platea dictumst etiam faucibus cursus urna ut tellus nulla ut erat id mauris vulputate elementum nullam varius nulla', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('orci vehicula condimentum curabitur in libero ut massa volutpat convallis', 8, 'eleifend luctus ultricies eu nibh quisque id justo sit amet sapien dignissim vestibulum vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae nulla dapibus dolor vel est donec odio justo sollicitudin ut suscipit a feugiat et eros vestibulum ac est lacinia', 'Closed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('vestibulum ante ipsum primis', 14, 'in faucibus orci luctus et ultrices posuere cubilia curae duis faucibus accumsan odio curabitur convallis duis consequat dui nec nisi volutpat eleifend donec ut dolor morbi vel lectus in quam fringilla rhoncus mauris enim leo rhoncus sed vestibulum sit amet cursus id turpis integer aliquet massa id lobortis convallis tortor risus dapibus augue vel accumsan tellus nisi eu orci', 'New');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('sollicitudin ut suscipit a feugiat et eros vestibulum ac est', 25, 'nibh fusce lacus purus aliquet at feugiat non pretium quis lectus suspendisse potenti in eleifend quam a odio in hac habitasse platea dictumst maecenas ut massa quis augue luctus tincidunt nulla mollis molestie lorem quisque ut erat curabitur gravida nisi at nibh in hac habitasse platea dictumst aliquam augue quam sollicitudin vitae consectetuer eget rutrum at lorem integer tincidunt ante vel ipsum praesent blandit lacinia erat vestibulum sed magna at nunc commodo placerat praesent blandit nam nulla integer', 'Closed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('pretium iaculis diam erat fermentum', 12, 'vestibulum sagittis sapien cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum neque aenean auctor gravida sem praesent id massa id nisl venenatis lacinia aenean sit amet justo morbi ut odio cras mi pede malesuada in imperdiet et commodo vulputate justo in blandit ultrices enim lorem ipsum dolor sit amet consectetuer adipiscing elit proin', 'New');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('nisi eu orci mauris lacinia sapien quis libero nullam', 17, 'quis orci eget orci vehicula condimentum curabitur in libero ut massa volutpat convallis morbi odio odio elementum eu interdum eu tincidunt in leo maecenas pulvinar lobortis est phasellus sit amet erat nulla tempus vivamus in felis eu sapien cursus vestibulum proin eu mi nulla ac enim in tempor turpis nec euismod scelerisque quam turpis adipiscing lorem vitae mattis nibh ligula nec sem duis aliquam convallis', 'Closed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('auctor gravida sem praesent id', 1, 'nullam molestie nibh in lectus pellentesque at nulla suspendisse potenti cras in purus eu magna vulputate luctus cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus vivamus vestibulum sagittis sapien cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum neque aenean auctor gravida sem praesent id massa id nisl venenatis lacinia aenean sit', 'Active');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('sapien sapien non mi integer ac neque duis', 1, 'eu est congue elementum in hac habitasse platea dictumst morbi vestibulum velit id pretium iaculis diam erat fermentum justo nec condimentum neque sapien placerat ante nulla justo aliquam quis turpis eget elit sodales scelerisque mauris sit amet eros suspendisse accumsan tortor quis turpis sed ante', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('neque duis bibendum morbi', 19, 'lectus in quam fringilla rhoncus mauris enim leo rhoncus sed vestibulum sit amet cursus id turpis integer aliquet massa id lobortis convallis tortor risus dapibus augue vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero nullam sit amet turpis elementum ligula vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor id nulla ultrices aliquet maecenas leo odio condimentum id luctus nec molestie sed justo pellentesque', 'New');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('nibh quisque id justo sit amet sapien dignissim vestibulum vestibulum', 9, 'massa id lobortis convallis tortor risus dapibus augue vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero nullam sit amet turpis elementum ligula vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor id nulla ultrices aliquet maecenas leo odio condimentum id luctus nec molestie sed justo pellentesque viverra pede ac', 'Resolved');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('quam a odio in hac habitasse platea', 21, 'at dolor quis odio consequat varius integer ac leo pellentesque ultrices mattis odio donec vitae nisi nam ultrices libero non mattis pulvinar nulla pede ullamcorper augue a suscipit nulla elit ac nulla sed vel enim sit amet nunc viverra dapibus nulla suscipit ligula in lacus curabitur at ipsum ac tellus semper interdum mauris ullamcorper purus', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('justo sollicitudin ut suscipit', 1, 'nam nulla integer pede justo lacinia eget tincidunt eget tempus vel pede morbi porttitor lorem id ligula suspendisse ornare consequat lectus in est risus auctor sed tristique in tempus sit amet sem fusce consequat nulla nisl nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit mi in porttitor pede justo eu massa donec dapibus duis at velit eu est congue elementum in hac habitasse platea dictumst morbi vestibulum velit id pretium iaculis diam erat fermentum justo nec condimentum', 'Closed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('praesent lectus vestibulum quam sapien varius ut blandit non interdum', 6, 'montes nascetur ridiculus mus vivamus vestibulum sagittis sapien cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum neque aenean auctor gravida sem praesent id massa id nisl venenatis lacinia aenean sit amet justo morbi ut odio cras mi pede malesuada in', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('ullamcorper purus sit amet nulla quisque arcu libero rutrum', 25, 'id lobortis convallis tortor risus dapibus augue vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero nullam sit amet turpis elementum ligula vehicula consequat morbi a ipsum integer a nibh in quis justo maecenas rhoncus aliquam lacus morbi quis tortor id nulla ultrices aliquet maecenas leo odio condimentum id luctus nec molestie sed justo pellentesque viverra pede ac diam cras pellentesque', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('justo morbi ut odio cras mi', 7, 'nulla nisl nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit mi in porttitor pede justo eu massa donec dapibus duis at velit eu est congue elementum in hac habitasse platea dictumst morbi vestibulum velit id pretium iaculis diam erat fermentum justo nec condimentum neque sapien placerat ante nulla justo aliquam quis turpis eget elit sodales scelerisque mauris sit amet eros suspendisse accumsan tortor quis turpis sed ante vivamus tortor duis mattis', 'New');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('in hac habitasse platea dictumst maecenas ut', 15, 'nulla tellus in sagittis dui vel nisl duis ac nibh fusce lacus purus aliquet at feugiat non pretium quis lectus suspendisse potenti in eleifend quam a odio in hac habitasse platea dictumst maecenas ut massa quis augue luctus tincidunt nulla mollis molestie', 'Active');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('proin risus praesent lectus vestibulum', 13, 'blandit nam nulla integer pede justo lacinia eget tincidunt eget tempus vel pede morbi porttitor lorem id ligula suspendisse ornare consequat lectus in est risus auctor sed tristique in tempus sit amet sem fusce consequat nulla nisl nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit mi in porttitor pede justo eu massa donec dapibus duis at velit eu est congue elementum', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('lacinia aenean sit amet justo morbi ut odio cras', 9, 'luctus et ultrices posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin mi sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi non quam nec dui luctus rutrum nulla tellus in sagittis dui vel nisl duis ac nibh fusce lacus purus aliquet at feugiat non pretium quis lectus suspendisse potenti in eleifend quam a odio in hac habitasse platea dictumst maecenas ut massa quis augue luctus tincidunt nulla mollis molestie', 'Active');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('felis eu sapien cursus vestibulum proin eu', 24, 'erat fermentum justo nec condimentum neque sapien placerat ante nulla justo aliquam quis turpis eget elit sodales scelerisque mauris sit amet eros suspendisse accumsan tortor quis turpis sed ante vivamus tortor duis mattis egestas metus aenean fermentum donec ut mauris', 'Active');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('leo rhoncus sed vestibulum sit amet cursus id turpis integer', 15, 'maecenas tristique est et tempus semper est quam pharetra magna ac consequat metus sapien ut nunc vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam porttitor lacus at turpis donec posuere metus vitae ipsum aliquam non mauris morbi non lectus aliquam sit amet diam in magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis sed', 'New');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('sapien ut nunc vestibulum ante ipsum', 2, 'ut massa quis augue luctus tincidunt nulla mollis molestie lorem quisque ut erat curabitur gravida nisi at nibh in hac habitasse platea dictumst aliquam augue quam sollicitudin vitae consectetuer eget rutrum at lorem integer tincidunt ante vel ipsum praesent blandit lacinia erat vestibulum sed magna at nunc commodo placerat praesent blandit nam nulla integer pede justo lacinia eget tincidunt eget tempus vel pede morbi porttitor', 'Closed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('lobortis vel dapibus at diam nam tristique tortor eu', 6, 'ut nunc vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae mauris viverra diam vitae quam suspendisse potenti nullam porttitor lacus at turpis donec posuere metus vitae ipsum aliquam non mauris morbi non lectus aliquam sit amet diam in magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce posuere felis sed lacus morbi sem mauris laoreet ut rhoncus aliquet', 'Resolved');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('tempus vel pede morbi porttitor lorem', 11, 'odio elementum eu interdum eu tincidunt in leo maecenas pulvinar lobortis est phasellus sit amet erat nulla tempus vivamus in felis eu sapien cursus vestibulum proin eu mi nulla ac enim in tempor turpis nec euismod scelerisque quam turpis adipiscing lorem vitae mattis nibh ligula nec sem duis aliquam convallis nunc proin at turpis a pede posuere nonummy integer non velit donec diam', 'New');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('curae nulla dapibus dolor vel est', 9, 'vel augue vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin mi sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi non quam nec dui luctus rutrum nulla tellus in', 'Closed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('mi nulla ac enim in tempor turpis', 6, 'vel pede morbi porttitor lorem id ligula suspendisse ornare consequat lectus in est risus auctor sed tristique in tempus sit amet sem fusce consequat nulla nisl nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit mi in porttitor pede justo eu massa donec dapibus duis at velit eu est congue elementum in hac habitasse platea dictumst morbi vestibulum velit id pretium iaculis diam erat fermentum justo nec condimentum neque sapien placerat ante nulla justo aliquam quis turpis eget', 'Active');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('feugiat et eros vestibulum ac est', 9, 'erat tortor sollicitudin mi sit amet lobortis sapien sapien non mi integer ac neque duis bibendum morbi non quam nec dui luctus rutrum nulla tellus in sagittis dui vel nisl duis ac nibh fusce lacus purus aliquet at feugiat non pretium quis lectus suspendisse potenti in eleifend quam a odio in hac habitasse platea dictumst maecenas ut massa quis augue luctus tincidunt nulla mollis molestie lorem quisque ut', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('aliquam non mauris morbi non lectus aliquam', 6, 'faucibus cursus urna ut tellus nulla ut erat id mauris vulputate elementum nullam varius nulla facilisi cras non velit nec nisi vulputate nonummy maecenas tincidunt lacus at velit vivamus vel nulla eget eros elementum pellentesque quisque porta volutpat erat quisque erat eros viverra eget congue eget semper rutrum nulla nunc purus phasellus in felis donec semper sapien', 'New');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('duis faucibus accumsan odio curabitur convallis', 15, 'dolor quis odio consequat varius integer ac leo pellentesque ultrices mattis odio donec vitae nisi nam ultrices libero non mattis pulvinar nulla pede ullamcorper augue a suscipit nulla elit ac nulla sed vel enim sit amet nunc viverra dapibus nulla suscipit ligula in lacus curabitur at ipsum ac', 'Resolved');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('condimentum neque sapien placerat ante', 24, 'lacinia eget tincidunt eget tempus vel pede morbi porttitor lorem id ligula suspendisse ornare consequat lectus in est risus auctor sed tristique in tempus sit amet sem fusce consequat nulla nisl nunc nisl duis bibendum felis sed interdum venenatis turpis enim blandit', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('nisi venenatis tristique fusce congue diam id ornare imperdiet sapien', 25, 'cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus etiam vel augue vestibulum rutrum rutrum neque aenean auctor gravida sem praesent id massa id nisl venenatis lacinia aenean sit amet justo morbi ut odio cras mi pede malesuada in imperdiet et commodo vulputate justo in blandit ultrices enim lorem ipsum dolor sit amet consectetuer adipiscing elit proin', 'Removed');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('etiam justo etiam pretium iaculis', 20, 'mi pede malesuada in imperdiet et commodo vulputate justo in blandit ultrices enim lorem ipsum dolor sit amet consectetuer adipiscing elit proin interdum mauris non ligula pellentesque ultrices phasellus id sapien in sapien iaculis congue vivamus metus arcu adipiscing molestie hendrerit at vulputate vitae nisl aenean lectus pellentesque eget nunc donec quis orci eget orci vehicula condimentum curabitur in libero ut massa volutpat convallis morbi', 'Active');");
            context.Database.ExecuteSqlRaw("insert into Tasks (Title, AssignedToId, Description, State) values ('nulla justo aliquam quis turpis eget elit sodales scelerisque mauris', 11, 'at feugiat non pretium quis lectus suspendisse potenti in eleifend quam a odio in hac habitasse platea dictumst maecenas ut massa quis augue luctus tincidunt nulla mollis molestie lorem quisque ut erat curabitur gravida nisi at nibh in hac habitasse platea dictumst aliquam augue quam sollicitudin vitae consectetuer eget rutrum at', 'New');");

            // Seed tags
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('client-driven');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Adaptive');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('capacity');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Cloned');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('transitional');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('User-centric');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('global');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Automated');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('core');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Distributed');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('human-resource');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Grass-roots');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Robust');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('clear-thinking');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('executive');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('project');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('asymmetric');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('frame');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Innovative');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Graphical User Interface');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('success');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('empowering');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Stand-alone');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('contingency');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('discrete');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('knowledge user');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Organic');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('methodical');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('zero administration');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('24 hour');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('adapter');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('interactive');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('conglomeration');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('utilisation');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('extranet');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Implemented');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Public-key');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Digitized');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Configurable');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('De-engineered');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('multi-state');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('policy');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('optimizing');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('hierarchy');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Sharable');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('impactful');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('actuating');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Synchronised');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('hub');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('database');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('paradigm');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('workforce');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('pricing structure');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('homogeneous');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('executive');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Operative');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('instruction set');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Streamlined');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('bifurcated');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Pre-emptive');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('installation');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('secured line');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Seamless');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('instruction set');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('high-level');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Focused');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('solution-oriented');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('monitoring');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('software');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Proactive');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Down-sized');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('collaboration');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Public-key');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('value-added');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('flexibility');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('24 hour');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('customer loyalty');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('mobile');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('client-driven');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Expanded');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('adapter');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Reverse-engineered');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('migration');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('optimizing');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('secondary');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Customizable');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Assimilated');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('ability');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('systematic');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Customer-focused');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('6th generation');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Progressive');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Cloned');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Multi-channelled');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Balanced');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('customer loyalty');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('array');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('Triple-buffered');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('zero tolerance');");
            context.Database.ExecuteSqlRaw("insert into Tags (name) values ('mission-critical');");

            // Connect tags and tasks


            context.SaveChanges();
        }
    }
}

