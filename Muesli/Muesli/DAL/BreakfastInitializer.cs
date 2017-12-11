using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Muesli.Models;

namespace Muesli.DAL
{
    public class BreakfastInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BreakfastContext>
    {
        protected override void Seed(Muesli.DAL.BreakfastContext context)
        {
       /*     var ingredients = new List<Ingredient> {
                new Ingredient{Name="Oat",Price=0.01m}, // base category: 6 items
                new Ingredient{Name="Buckwheat",Price=0.02m},
                new Ingredient{Name="Wheat",Price=0.03m},
                new Ingredient{Name="Corn",Price=0.04m},
                new Ingredient{Name="Barley",Price=0.05m},
                new Ingredient{Name="Rice",Price=0.06m},
                new Ingredient{Name="Pineapple",Price=0.07m}, // fruit category: 14 items
                new Ingredient{Name="Banana",Price=0.08m},
                new Ingredient{Name="Dates",Price=0.09m},
                new Ingredient{Name="Cherry",Price=0.10m},
                new Ingredient{Name="Melon",Price=0.11m},
                new Ingredient{Name="Apple",Price=0.12m},
                new Ingredient{Name="Raisins",Price=0.13m},
                new Ingredient{Name="Cranberries",Price=0.14m},
                new Ingredient{Name="Peach",Price=0.15m},
                new Ingredient{Name="Orange",Price=0.16m},
                new Ingredient{Name="Grapefruit",Price=0.17m},
                new Ingredient{Name="Mango",Price=0.18m},
                new Ingredient{Name="Papaya",Price=0.19m},
                new Ingredient{Name="Plum",Price=0.20m},
                new Ingredient{Name="Cashew",Price=0.21m}, // nut category: 6 items
                new Ingredient{Name="Brazil",Price=0.22m},
                new Ingredient{Name="Walnut",Price=0.23m},
                new Ingredient{Name="Hazelnut",Price=0.24m},
                new Ingredient{Name="Almond",Price=0.25m},
                new Ingredient{Name="Peanut",Price=0.26m},
                new Ingredient{Name="Linseed",Price=0.27m}, // seed category: 7 items
                new Ingredient{Name="Sesam",Price=0.28m},
                new Ingredient{Name="Chia",Price=0.29m},
                new Ingredient{Name="Pumpkin",Price=0.30m},
                new Ingredient{Name="Sunflower",Price=0.31m},
                new Ingredient{Name="Poppy",Price=0.32m},
                new Ingredient{Name="Cannabis",Price=0.33m},
                new Ingredient{Name="Cinnamon",Price=0.34m}, // others category: 3 items
                new Ingredient{Name="Chocolate",Price=0.35m},
                new Ingredient{Name="Ginger",Price=0.36m} // total:  36 items
                // new Ingredient{Name="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            ingredients.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();

            var categories = new List<Category> {
                new Category{CategoryId=1,CatName="Base"},
                new Category{CategoryId=2,CatName="Fruits"},
                new Category{CategoryId=3,CatName="Nuts"},
                new Category{CategoryId=4,CatName="Seeds"},
                new Category{CategoryId=5,CatName="Others"}
                // new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var ingredient_categories = new List<Ingredient_Category>{
                new Ingredient_Category{IngredientId=1,CategoryId=01},
                new Ingredient_Category{IngredientId=2,CategoryId=01},
                new Ingredient_Category{IngredientId=3,CategoryId=01},
                new Ingredient_Category{IngredientId=4,CategoryId=01},
                new Ingredient_Category{IngredientId=5,CategoryId=01},
                new Ingredient_Category{IngredientId=6,CategoryId=01}, // iki cia
                new Ingredient_Category{IngredientId=7,CategoryId=02},
                new Ingredient_Category{IngredientId=8,CategoryId=02},
                new Ingredient_Category{IngredientId=9,CategoryId=02},
                new Ingredient_Category{IngredientId=10,CategoryId=02},
                new Ingredient_Category{IngredientId=11,CategoryId=02},
                new Ingredient_Category{IngredientId=12,CategoryId=02},
                new Ingredient_Category{IngredientId=13,CategoryId=02},
                new Ingredient_Category{IngredientId=14,CategoryId=02},
                new Ingredient_Category{IngredientId=15,CategoryId=02},
                new Ingredient_Category{IngredientId=16,CategoryId=02},
                new Ingredient_Category{IngredientId=17,CategoryId=02},
                new Ingredient_Category{IngredientId=18,CategoryId=02},
                new Ingredient_Category{IngredientId=19,CategoryId=02},
                new Ingredient_Category{IngredientId=20,CategoryId=02}, // iki cia
                new Ingredient_Category{IngredientId=21,CategoryId=03},
                new Ingredient_Category{IngredientId=22,CategoryId=03},
                new Ingredient_Category{IngredientId=23,CategoryId=03},
                new Ingredient_Category{IngredientId=24,CategoryId=03},
                new Ingredient_Category{IngredientId=25,CategoryId=03},
                new Ingredient_Category{IngredientId=26,CategoryId=03}, // iki cia
                new Ingredient_Category{IngredientId=27,CategoryId=04},
                new Ingredient_Category{IngredientId=28,CategoryId=04},
                new Ingredient_Category{IngredientId=29,CategoryId=04},
                new Ingredient_Category{IngredientId=30,CategoryId=04},
                new Ingredient_Category{IngredientId=31,CategoryId=04},
                new Ingredient_Category{IngredientId=32,CategoryId=04},
                new Ingredient_Category{IngredientId=33,CategoryId=04}, // iki cia
                new Ingredient_Category{IngredientId=34,CategoryId=05},
                new Ingredient_Category{IngredientId=35,CategoryId=05},
                new Ingredient_Category{IngredientId=36,CategoryId=05}
                // new Ingredient_Category{StudentID=7,CourseID=3141,Grade=Grade.A}
            };
            ingredient_categories.ForEach(s => context.Ingredient_Categories.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User{Username="user1",FirstName="UserFirstName1",LastName="UserLastName1",Email="email1@gmail.com"},
                new User{Username="user2",FirstName="UserFirstName2",LastName="UserLastName2",Email="email2@gmail.com"},
                new User{Username="user3",FirstName="UserFirstName3",LastName="UserLastName3",Email="email3@gmail.com"},
                new User{Username="user4",FirstName="UserFirstName4",LastName="UserLastName4",Email="email4@gmail.com"},
                new User{Username="user5",FirstName="UserFirstName5",LastName="UserLastName5",Email="email5@gmail.com"},
                new User{Username="user6",FirstName="UserFirstName6",LastName="UserLastName6",Email="email6@gmail.com"}, 
                new User{Username="user7",FirstName="UserFirstName7",LastName="UserLastName7",Email="email7@gmail.com"},
                new User{Username="user8",FirstName="UserFirstName8",LastName="UserLastName8",Email="email8@gmail.com"},
                new User{Username="user9",FirstName="UserFirstName9",LastName="UserLastName9",Email="email9@gmail.com"}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var subscriptions = new List<Subscription>
            {
                new Subscription{SubscriptionId=1,Date_created=new DateTime(2016,01,12),Delivery_frequency=60,Price=13.00m},
                new Subscription{SubscriptionId=2,Date_created=new DateTime(2017,02,13),Delivery_frequency=7,Price=14.00m},
                new Subscription{SubscriptionId=3,Date_created=new DateTime(2017,03,14),Delivery_frequency=90,Price=18.00m},
                new Subscription{SubscriptionId=4,Date_created=new DateTime(2017,04,11),Delivery_frequency=10,Price=15.00m},
                new Subscription{SubscriptionId=5,Date_created=new DateTime(2017,05,10),Delivery_frequency=45,Price=19.00m},
                new Subscription{SubscriptionId=6,Date_created=new DateTime(2016,06,11),Delivery_frequency=90,Price=12.00m},
                new Subscription{SubscriptionId=7,Date_created=new DateTime(2016,07,12),Delivery_frequency=100,Price=15.00m},
                new Subscription{SubscriptionId=8,Date_created=new DateTime(2017,08,13),Delivery_frequency=66,Price=20.00m},
                new Subscription{SubscriptionId=9,Date_created=new DateTime(2017,09,10),Delivery_frequency=55,Price=21.00m},
                new Subscription{SubscriptionId=10,Date_created=new DateTime(2015,10,11),Delivery_frequency=44,Price=12.00m},
                new Subscription{SubscriptionId=11,Date_created=new DateTime(2016,11,12),Delivery_frequency=33,Price=13.00m},
                new Subscription{SubscriptionId=12,Date_created=new DateTime(2016,12,13),Delivery_frequency=33,Price=14.00m},
                new Subscription{SubscriptionId=13,Date_created=new DateTime(2017,10,10),Delivery_frequency=22,Price=15.00m},
                new Subscription{SubscriptionId=14,Date_created=new DateTime(2014,03,11),Delivery_frequency=12,Price=16.00m},
                new Subscription{SubscriptionId=15,Date_created=new DateTime(2017,02,12),Delivery_frequency=23,Price=17.00m},
                new Subscription{SubscriptionId=16,Date_created=new DateTime(2017,06,13),Delivery_frequency=43,Price=18.00m},
                new Subscription{SubscriptionId=17,Date_created=new DateTime(2017,05,10),Delivery_frequency=21,Price=19.00m},
                new Subscription{SubscriptionId=18,Date_created=new DateTime(2017,01,11),Delivery_frequency=21,Price=20.00m},
                new Subscription{SubscriptionId=19,Date_created=new DateTime(2017,03,12),Delivery_frequency=28,Price=21.00m},
                new Subscription{SubscriptionId=20,Date_created=new DateTime(2017,12,13),Delivery_frequency=30,Price=22.00m}
            };
            subscriptions.ForEach(s => context.Subscriptions.Add(s));
            context.SaveChanges();

            var user_subscriptions = new List<User_Subscription>
            {
                new User_Subscription{SubscriptionId=1,UserId=1},
                new User_Subscription{SubscriptionId=2,UserId=2},
                new User_Subscription{SubscriptionId=3,UserId=1},
                new User_Subscription{SubscriptionId=4,UserId=3},
                new User_Subscription{SubscriptionId=5,UserId=4},
                new User_Subscription{SubscriptionId=6,UserId=5},
                new User_Subscription{SubscriptionId=7,UserId=6},
                new User_Subscription{SubscriptionId=8,UserId=6},
                new User_Subscription{SubscriptionId=9,UserId=6},
                new User_Subscription{SubscriptionId=10,UserId=7},
                new User_Subscription{SubscriptionId=11,UserId=7},
                new User_Subscription{SubscriptionId=12,UserId=1},
                new User_Subscription{SubscriptionId=13,UserId=2},
                new User_Subscription{SubscriptionId=14,UserId=8},
                new User_Subscription{SubscriptionId=15,UserId=1},
                new User_Subscription{SubscriptionId=16,UserId=8},
                new User_Subscription{SubscriptionId=17,UserId=9},
                new User_Subscription{SubscriptionId=18,UserId=9},
                new User_Subscription{SubscriptionId=19,UserId=9},
                new User_Subscription{SubscriptionId=20,UserId=9}
            };
            user_subscriptions.ForEach(s => context.User_Subscriptions.Add(s));
            context.SaveChanges();*/
        }
    }
}