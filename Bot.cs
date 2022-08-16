using Kursach.Client;
using KursachBot.Model;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Kursach.SendSMS;

namespace KursachBot
{

    public class Bot
    {
        public string LastText;
        public string calories;
        public string dontlike;
        public string diet;
        public int id;
        public string mail;
        public string number;
        public string text;
        public String[] array;

        TelegramBotClient botClient = new TelegramBotClient("5304640096:AAH0J12Cnr5ilL16uJzGpo3j8yZO5C9iae0");
        CancellationToken cancellationToken = new CancellationToken();
        ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
        public async Task Start()
        {
            botClient.StartReceiving(HandlerUpdateAsync, HandlerError, receiverOptions, cancellationToken);
            var botMe = await botClient.GetMeAsync();
            Console.WriteLine($"Bot {botMe.Username} started working");
            Console.ReadKey();
        }

        private Task HandlerError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Error telegram API:\n {apiRequestException.ErrorCode}" +
                $"\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
        
        private async Task HandlerUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                await HandlerMessage(botClient, update.Message, cancellationToken, ParseMode.Html);
            }
        }
        private async Task HandlerMessage(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, ParseMode HTML)
        {
            

            if (message.Text == "/start")
            {
                message.Text = LastText;
                await botClient.SendTextMessageAsync(message.Chat.Id, "Hi👋, I'm MealBot 🤖\nIf you want to create your own MealPlan,\nchoose your diet, from the allowed✅");
                await botClient.SendTextMessageAsync(message.Chat.Id, "Allowed diets ✅:\n1⃣ Whole30 🚫🥂\n2⃣ Gluten Free 🚫🍞\n3⃣ Ketogenic 🚫💊\n4⃣ Vegetarian 🥦\n5⃣ Lacto-Vegetarian 🥛\n6⃣ Vegan 🚫🐻🔫‍\n7⃣ Pescetarian 🐟\n8⃣ Primal 🦣");
                ReplyKeyboardMarkup replyKeyboardMarkup = new
                        (
                        new[]
                            {
                        new KeyboardButton [] { "Whole30"}, new KeyboardButton [] { "Gluten Free"}, new KeyboardButton [] { "Ketogenic"},
                        new KeyboardButton [] { "Vegetarian"}, new KeyboardButton [] { "Lacto-Vegetarian"},
                         new KeyboardButton [] { "Vegan"}, new KeyboardButton [] { "Pescetarian"}, new KeyboardButton [] { "Primal"},
                            }
                        )
                {
                    ResizeKeyboard = true
                };
                await botClient.SendTextMessageAsync(message.Chat.Id, "Make your choice👌!", replyMarkup: replyKeyboardMarkup);
                return;
            }
            else
                
                if (message.Text == "Whole30")
            {
                diet = message.Text;
                LastText = "Enter food you dont like";
                message.Text = "Enter food you dont like";
                await botClient.SendTextMessageAsync(message.Chat.Id, "💁‍♀️Enter an ingredient you don't like🤢\nor don't want to see in your plan📃", replyMarkup: new ForceReplyMarkup() { Selective = true });
                Console.WriteLine($"diet - {diet}");
                LastText = "Enter food you dont like";
            }
            else
            if (message.Text == "Gluten Free")
            {
                diet = message.Text;
                LastText = "Enter food you dont like";
                message.Text = "Enter food you dont like";
                await botClient.SendTextMessageAsync(message.Chat.Id, "💁‍♀️Enter an ingredient you don't like🤢\nor don't want to see in your plan📃", replyMarkup: new ForceReplyMarkup() { Selective = true });
                Console.WriteLine($"diet - {diet}");
                LastText = "Enter food you dont like";
            }
            else
            if (message.Text == "Ketogenic")
            {
                diet = message.Text;
                LastText = "Enter food you dont like";
                message.Text = "Enter food you dont like";
                await botClient.SendTextMessageAsync(message.Chat.Id, "💁‍♀️Enter an ingredient you don't like🤢\nor don't want to see in your plan📃", replyMarkup: new ForceReplyMarkup() { Selective = true });
                Console.WriteLine($"diet - {diet}");
                LastText = "Enter food you dont like";
            }
            else
            if (message.Text == "Vegetarian")
            {
                diet = message.Text;
                LastText = "Enter food you dont like";
                message.Text = "Enter food you dont like";
                await botClient.SendTextMessageAsync(message.Chat.Id, "💁‍♀️Enter an ingredient you don't like🤢\nor don't want to see in your plan📃", replyMarkup: new ForceReplyMarkup() { Selective = true });
                Console.WriteLine($"diet - {diet}");
                LastText = "Enter food you dont like";
            }
            else
            if (message.Text == "Lacto-Vegetarian")
            {
                diet = message.Text;
                LastText = "Enter food you dont like";
                message.Text = "Enter food you dont like";
                await botClient.SendTextMessageAsync(message.Chat.Id, "💁‍♀️Enter an ingredient you don't like🤢\nor don't want to see in your plan📃", replyMarkup: new ForceReplyMarkup() { Selective = true });
                Console.WriteLine($"diet - {diet}");
                LastText = "Enter food you dont like";
            }
            else
            if (message.Text == "Vegan")
            {
                diet = message.Text;
                LastText = "Enter food you dont like";
                message.Text = "Enter food you dont like";
                await botClient.SendTextMessageAsync(message.Chat.Id, "💁‍♀️Enter an ingredient you don't like🤢\nor don't want to see in your plan📃", replyMarkup: new ForceReplyMarkup() { Selective = true });
                Console.WriteLine($"diet - {diet}");
                LastText = "Enter food you dont like";
            }
            else
            if (message.Text == "Pescetarian")
            {
                diet = message.Text;
                LastText = "Enter food you dont like";
                message.Text = "Enter food you dont like";
                await botClient.SendTextMessageAsync(message.Chat.Id, "💁‍♀️Enter an ingredient you don't like🤢\nor don't want to see in your plan📃", replyMarkup: new ForceReplyMarkup() { Selective = true });
                Console.WriteLine($"diet - {diet}");
                LastText = "Enter food you dont like";
            }
            else
            if (message.Text == "Paleo")
            {
                diet = message.Text;
                LastText = "Enter food you dont like";
                message.Text = "Enter food you dont like";
                await botClient.SendTextMessageAsync(message.Chat.Id, "💁‍♀️Enter an ingredient you don't like🤢\nor don't want to see in your plan📃", replyMarkup: new ForceReplyMarkup() { Selective = true });
                Console.WriteLine($"diet - {diet}");
                LastText = "Enter food you dont like";
            }
            else
            if (message.Text == "Primal")
            {
                diet = message.Text;
                LastText = "Enter food you dont like";
                message.Text = "Enter food you dont like";
                await botClient.SendTextMessageAsync(message.Chat.Id, "💁‍♀️Enter an ingredient you don't like🤢\nor don't want to see in your plan📃", replyMarkup: new ForceReplyMarkup() { Selective = true });
                Console.WriteLine($"diet - {diet}");
                LastText = "Enter food you dont like";
            }
            else
                if (LastText == "Enter food you dont like")
            {
                string Str = message.Text.Trim();

                decimal Num;

                bool isNum = decimal.TryParse(Str, out Num);

                if (isNum)

                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "You entered number 🔢 , please enter food you dont like❗");
                }

                else

                {
                    dontlike = message.Text;
                    Console.WriteLine($"dontlike - {dontlike}");
                    LastText = "Enter ✍ the number of calories that will be in your daily diet 📊";
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Enter ✍ the number of calories that will be in your daily diet 📊", replyMarkup: new ForceReplyMarkup() { Selective = true });
                }
                
            }
            else
                if (LastText == "Enter ✍ the number of calories that will be in your daily diet 📊")
            {
                string Str = message.Text.Trim();

                decimal Num;

                bool isNum = decimal.TryParse(Str, out Num);

                if (isNum)

                {
                    calories = message.Text;
                    Console.WriteLine($"calories - {calories}");
                    //await botClient.SendTextMessageAsync(message.Chat.Id, "➡ /GenerateGraphic ⬅");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Enter your phone number 📞(format: 380..) ,\nwhere we will send your daily plan💖", replyMarkup: new ForceReplyMarkup() { Selective = true });
                    message.Text = "Enter your phone";
                    LastText = "Enter your phone";
                }

                else

                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "You entered text 📝 , please enter the number of calories❗");
                }
            }
            else
            if(LastText == "Enter your phone")
            {
                if (message.Text.StartsWith("380"))
                {
                    number = message.Text.Trim();

                    decimal Num;

                    bool isNum = decimal.TryParse(number, out Num);

                    if (isNum)

                    {
                        number = message.Text;
                        Console.Write(number);
                        MealClient ws = new MealClient();
                        Phone phone = new Phone() { phoneNumber = message.Text };
                        await ws.PostNumber(phone);
                        await botClient.SendTextMessageAsync(message.Chat.Id, "➡ /SendGraphic ⬅");
                        LastText = "➡ /SendGraphic ⬅";
                    }

                    else

                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "You entered text 📝 , please enter your phone number ❗");
                    }
                }
                else
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Wrong number 😞 , pls enter your number from 380");
            }

            else
                if (message.Text == "/SendGraphic")
            {
                ReplyKeyboardMarkup replyKeyboardMarkup1 = new
                    (
                    new[]
                        {
                        new KeyboardButton [] { "Sunday"},
                        new KeyboardButton [] { "Monday"},
                        new KeyboardButton [] { "Tuesday"},
                        new KeyboardButton [] { "Wednesday"},
                        new KeyboardButton [] { "Thursday"},
                        new KeyboardButton [] { "Friday"},
                        new KeyboardButton [] { "Saturday"},
                        }
                    )
                {
                    OneTimeKeyboard = true,
                    ResizeKeyboard = true
                };
                await botClient.SendTextMessageAsync(message.Chat.Id, "Choose a day of the week📆", replyMarkup: replyKeyboardMarkup1);
                return;
            }
            else
                if (message.Text == "Sunday")
            {
                try
                {
                    message.Text = "";
                    MealClient ws = new MealClient();
                    var mealGraphic = ws.GenerateMealGraphic($"{diet}", $"{dontlike}", $"{calories}").Result;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize<MealGraphic>(mealGraphic, options);
                    MealGraphic? graphic = JsonSerializer.Deserialize<MealGraphic>(json);
                    //            await botClient.SendTextMessageAsync(message.Chat.Id, text: $"Sunday ✅\n" + "\nBreakfast meal 🍳 - " + graphic.week.sunday.meals[0].title + "\n" + "Meal 🆔 - " + graphic.week.sunday.meals[0].id + "\nDinner meal 🍝 - " + graphic.week.sunday.meals[1].title + "\n" + "Meal 🆔 - " + graphic.week.sunday.meals[1].id + "\nEvening meal 🍽 - " + graphic.week.sunday.meals[2].title + "\n" + "Meal 🆔 - " + graphic.week.sunday.meals[2].id
                    //+ "\n" + "\nTotal number of calories 🔝 - " + graphic.week.sunday.nutrients.calories);
                    text = $"Sunday ✅\n" + "\nBreakfast meal - " + graphic.week.sunday.meals[0].title + "\n" + "Meal ID - " + graphic.week.sunday.meals[0].id + "\nDinner meal - " + graphic.week.sunday.meals[1].title + "\n" + "Meal ID - " + graphic.week.sunday.meals[1].id + "\nEvening meal - " + graphic.week.sunday.meals[2].title + "\n" + "Meal ID - " + graphic.week.sunday.meals[2].id
                    + "\n" + "\nTotal number of calories - " + graphic.week.sunday.nutrients.calories;
                    string[] vs = { number };
                    SMSmodel model = new SMSmodel() { message = text, phone = vs };
                    SMSclient sMSclient = new SMSclient(); ;
                    sMSclient.SendSMS(model);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Success 💫 ! Message was sent 📩 , wait 10-15 seconds");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "If you would like to get some information about meal,\nchoose /getmealinformation");

                    return;
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Something went wrong...\nPleast write /start , and try again");
                }
            }
            else
                if (message.Text == "Monday")
            {
                try
                {
                    MealClient ws = new MealClient();
                    var mealGraphic = ws.GenerateMealGraphic($"{diet}", $"{dontlike}", $"{calories}").Result;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize<MealGraphic>(mealGraphic, options);
                    MealGraphic? graphic = JsonSerializer.Deserialize<MealGraphic>(json);
        //            await botClient.SendTextMessageAsync(message.Chat.Id, text: $"Monday ✅\n" + "\nBreakfast meal 🍳 - " + graphic.week.monday.meals[0].title + "\n" + "Meal 🆔 - " + graphic.week.monday.meals[0].id + "\nDinner meal 🍝 - " + graphic.week.monday.meals[1].title + "\n" + "Meal 🆔 - " + graphic.week.monday.meals[1].id + "\nEvening meal 🍽 - " + graphic.week.monday.meals[2].title + "\n" + "Meal 🆔 - " + graphic.week.monday.meals[2].id
        //+ "\n" + "\nTotal number of calories 🔝 - " + graphic.week.monday.nutrients.calories);

                    text = $"Monday ✅\n" + "\nBreakfast meal - " + graphic.week.monday.meals[0].title + "\n" + "Meal ID - " + graphic.week.monday.meals[0].id + "\nDinner meal - " + graphic.week.monday.meals[1].title + "\n" + "Meal ID - " + graphic.week.monday.meals[1].id + "\nEvening meal - " + graphic.week.monday.meals[2].title + "\n" + "Meal ID - " + graphic.week.monday.meals[2].id
        + "\n" + "\nTotal number of calories - " + graphic.week.monday.nutrients.calories;
                    string[] vs = { number };
                    SMSmodel model = new SMSmodel() { message = text, phone = vs };
                    SMSclient sMSclient = new SMSclient(); ;
                    sMSclient.SendSMS(model);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Success 💫 ! Message was sent 📩 , wait 10-15 seconds");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "If you would like to get some information about meal,\nchoose /getmealinformation");
                    return;
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Something went wrong...\nPleast write /start , and try again");
                }
            }
            else
                if (message.Text == "Tuesday")
            {
                try
                {
                    MealClient ws = new MealClient();
                    var mealGraphic = ws.GenerateMealGraphic($"{diet}", $"{dontlike}", $"{calories}").Result;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize<MealGraphic>(mealGraphic, options);
                    MealGraphic? graphic = JsonSerializer.Deserialize<MealGraphic>(json);
                    //            await botClient.SendTextMessageAsync(message.Chat.Id, text: $"Tuesday ✅\n" + "\nBreakfast meal 🍳 - " + graphic.week.tuesday.meals[0].title + "\n" + "Meal 🆔 - " + graphic.week.tuesday.meals[0].id + "\nDinner meal 🍝 - " + graphic.week.tuesday.meals[1].title + "\n" + "Meal 🆔 - " + graphic.week.tuesday.meals[1].id + "\nEvening meal 🍽 - " + graphic.week.tuesday.meals[2].title + "\n" + "Meal 🆔 - " + graphic.week.tuesday.meals[2].id
                    //+ "\n" + "\nTotal number of calories 🔝 - " + graphic.week.tuesday.nutrients.calories);
                    text = $"Tuesday ✅\n" + "\nBreakfast meal - " + graphic.week.tuesday.meals[0].title + "\n" + "Meal ID - " + graphic.week.tuesday.meals[0].id + "\nDinner meal - " + graphic.week.tuesday.meals[1].title + "\n" + "Meal ID - " + graphic.week.tuesday.meals[1].id + "\nEvening meal - " + graphic.week.tuesday.meals[2].title + "\n" + "Meal ID - " + graphic.week.tuesday.meals[2].id
                    + "\n" + "\nTotal number of calories - " + graphic.week.tuesday.nutrients.calories;
                    string[] vs = { number };
                    SMSmodel model = new SMSmodel() { message = text, phone = vs };
                    SMSclient sMSclient = new SMSclient(); ;
                    sMSclient.SendSMS(model);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Success 💫 ! Message was sent 📩 , wait 10-15 seconds");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "If you would like to get some information about meal,\nchoose /getmealinformation");
                    return;
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Something went wrong...\nPleast write /start , and try again");
                }

            }
            else
                if (message.Text == "Wednesday")
            {
                try
                {
                    MealClient ws = new MealClient();
                    var mealGraphic = ws.GenerateMealGraphic($"{diet}", $"{dontlike}", $"{calories}").Result;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize<MealGraphic>(mealGraphic, options);
                    MealGraphic? graphic = JsonSerializer.Deserialize<MealGraphic>(json);
                    //            await botClient.SendTextMessageAsync(message.Chat.Id, text: $"Wednesday ✅\n" + "\nBreakfast meal 🍳 - " + graphic.week.wednesday.meals[0].title + "\n" + "Meal 🆔 - " + graphic.week.wednesday.meals[0].id + "\nDinner meal 🍝 - " + graphic.week.wednesday.meals[1].title + "\n" + "Meal 🆔 - " + graphic.week.wednesday.meals[1].id + "\nEvening meal 🍽 - " + graphic.week.wednesday.meals[2].title + "\n" + "Meal 🆔 - " + graphic.week.wednesday.meals[2].id
                    //+ "\n" + "\nTotal number of calories 🔝 - " + graphic.week.wednesday.nutrients.calories);
                    text = $"Wednesday ✅\n" + "\nBreakfast meal - " + graphic.week.wednesday.meals[0].title + "\n" + "Meal ID - " + graphic.week.wednesday.meals[0].id + "\nDinner meal - " + graphic.week.wednesday.meals[1].title + "\n" + "Meal ID - " + graphic.week.wednesday.meals[1].id + "\nEvening meal - " + graphic.week.wednesday.meals[2].title + "\n" + "Meal ID - " + graphic.week.wednesday.meals[2].id
                                + "\n" + "\nTotal number of calories - " + graphic.week.wednesday.nutrients.calories;
                    string[] vs = { number };
                    SMSmodel model = new SMSmodel() { message = text, phone = vs };
                    SMSclient sMSclient = new SMSclient(); ;
                    sMSclient.SendSMS(model);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Success 💫 ! Message was sent 📩 , wait 10-15 seconds");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "If you would like to get some information about meal,\nchoose /getmealinformation");
                    return;
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Something went wrong...\nPleast write /start , and try again");
                }
            }
            else
                if (message.Text == "Thursday")
            {
                try
                {
                    MealClient ws = new MealClient();
                    var mealGraphic = ws.GenerateMealGraphic($"{diet}", $"{dontlike}", $"{calories}").Result;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize<MealGraphic>(mealGraphic, options);
                    MealGraphic? graphic = JsonSerializer.Deserialize<MealGraphic>(json);
                    //            await botClient.SendTextMessageAsync(message.Chat.Id, text: $"Thursday ✅\n" + "\nBreakfast meal 🍳 - " + graphic.week.thursday.meals[0].title + "\n" + "Meal 🆔 - " + graphic.week.thursday.meals[0].id + "\nDinner meal 🍝 - " + graphic.week.thursday.meals[1].title + "\n" + "Meal 🆔 - " + graphic.week.thursday.meals[1].id + "\nEvening meal 🍽 - " + graphic.week.thursday.meals[2].title + "\n" + "Meal 🆔 - " + graphic.week.thursday.meals[2].id
                    //+ "\n" + "\nTotal number of calories 🔝 - " + graphic.week.thursday.nutrients.calories);
                    text = $"Thursday ✅\n" + "\nBreakfast meal - " + graphic.week.thursday.meals[0].title + "\n" + "Meal ID - " + graphic.week.thursday.meals[0].id + "\nDinner meal - " + graphic.week.thursday.meals[1].title + "\n" + "Meal ID - " + graphic.week.thursday.meals[1].id + "\nEvening meal - " + graphic.week.thursday.meals[2].title + "\n" + "Meal ID - " + graphic.week.thursday.meals[2].id
                                            + "\n" + "\nTotal number of calories - " + graphic.week.thursday.nutrients.calories;
                    string[] vs = { number };
                    SMSmodel model = new SMSmodel() { message = text, phone = vs };
                    SMSclient sMSclient = new SMSclient(); ;
                    sMSclient.SendSMS(model);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Success 💫 ! Message was sent 📩 , wait 10-15 seconds");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "If you would like to get some information about meal,\nchoose /getmealinformation");
                    return;
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Something went wrong...\nPleast write /start , and try again");
                }
            }
            else
                if (message.Text == "Friday")
            {
                try
                {
                    MealClient ws = new MealClient();
                    var mealGraphic = ws.GenerateMealGraphic($"{diet}", $"{dontlike}", $"{calories}").Result;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize<MealGraphic>(mealGraphic, options);
                    MealGraphic? graphic = JsonSerializer.Deserialize<MealGraphic>(json);
                    //            await botClient.SendTextMessageAsync(message.Chat.Id, text: $"Friday ✅\n" + "\nBreakfast meal 🍳 - " + graphic.week.friday.meals[0].title + "\n" + "Meal 🆔 - " + graphic.week.friday.meals[0].id + "\nDinner meal 🍝 - " + graphic.week.friday.meals[1].title + "\n" + "Meal 🆔 - " + graphic.week.friday.meals[1].id + "\nEvening meal 🍽 - " + graphic.week.friday.meals[2].title + "\n" + "Meal 🆔 - " + graphic.week.friday.meals[2].id
                    //+ "\n" + "\nTotal number of calories 🔝 - " + graphic.week.friday.nutrients.calories);
                    text = $"Friday ✅\n" + "\nBreakfast meal - " + graphic.week.friday.meals[0].title + "\n" + "Meal ID - " + graphic.week.friday.meals[0].id + "\nDinner meal - " + graphic.week.friday.meals[1].title + "\n" + "Meal ID - " + graphic.week.friday.meals[1].id + "\nEvening meal - " + graphic.week.friday.meals[2].title + "\n" + "Meal ID - " + graphic.week.friday.meals[2].id
                                                        + "\n" + "\nTotal number of calories - " + graphic.week.friday.nutrients.calories;
                    string[] vs = { number };
                    SMSmodel model = new SMSmodel() { message = text, phone = vs };
                    SMSclient sMSclient = new SMSclient(); ;
                    sMSclient.SendSMS(model);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Success 💫 ! Message was sent 📩 , wait 10-15 seconds");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "If you would like to get some information about meal,\nchoose /getmealinformation");
                    return;
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Something went wrong...\nPleast write /start , and try again");
                }

            }
            else
                if (message.Text == "Saturday")
            {
                try
                {
                    MealClient ws = new MealClient();
                    var mealGraphic = ws.GenerateMealGraphic($"{diet}", $"{dontlike}", $"{calories}").Result;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize<MealGraphic>(mealGraphic, options);
                    MealGraphic? graphic = JsonSerializer.Deserialize<MealGraphic>(json);
                    //await botClient.SendTextMessageAsync(message.Chat.Id, text: $"Saturday ✅\n" + "\nBreakfast meal 🍳 - " + graphic.week.saturday.meals[0].title + "\n" + "Meal 🆔 - " + graphic.week.saturday.meals[0].id + "\nDinner meal 🍝 - " + graphic.week.saturday.meals[1].title + "\n" + "Meal 🆔 - " + graphic.week.saturday.meals[1].id + "\nEvening meal 🍽 - " + graphic.week.saturday.meals[2].title + "\n" + "Meal 🆔 - " + graphic.week.saturday.meals[2].id
                    //+ "\n" + "\nTotal number of calories 🔝 - " + graphic.week.saturday.nutrients.calories);
                    text = $"Saturday ✅\n" + "\nBreakfast meal - " + graphic.week.saturday.meals[0].title + "\n" + "Meal ID - " + graphic.week.saturday.meals[0].id + "\nDinner meal - " + graphic.week.saturday.meals[1].title + "\n" + "Meal ID - " + graphic.week.saturday.meals[1].id + "\nEvening meal - " + graphic.week.saturday.meals[2].title + "\n" + "Meal ID - " + graphic.week.saturday.meals[2].id
                                                                    + "\n" + "\nTotal number of calories - " + graphic.week.saturday.nutrients.calories;
                    string[] vs = { number };
                    SMSmodel model = new SMSmodel() { message = text, phone = vs };
                    SMSclient sMSclient = new SMSclient(); ;
                    sMSclient.SendSMS(model);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Success 💫 ! Message was sent 📩 , wait 10-15 seconds");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "If you would like to get some information about meal,\nchoose /getmealinformation");
                    return;
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Something went wrong...\nPleast rewrite /start , and try again");
                }
            }
            if (message.Text == "/getmealinformation")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Send an 🆔 of yours meal🍩");
                message.Text = "Send an 🆔 of yours meal";
                LastText = "Send an 🆔 of yours meal 🍩";
            }
            
            else
            if(LastText == "Send an 🆔 of yours meal 🍩")
            {
                try
                {
                    id = Int32.Parse(message.Text);
                    Console.WriteLine(id);
                    MealClient ws = new MealClient();
                    var meal = ws.GetFindMealAsync($"{id}").Result;
                    ws.PostMeal(meal);
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize(meal, options);
                    Model.Model? graphic = JsonSerializer.Deserialize<Model.Model>(json);
                    if (graphic.id != 0)
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Your meal 👌 - " + graphic.title + "\nMeal 🆔 - " + meal.id + "\n                                            Summary 🤩 " + "\n" + meal.summary, ParseMode.Html);

                    }
                    else
                        await botClient.SendTextMessageAsync(message.Chat.Id, "This 🆔 don't exist ❌");
                }


                catch
                {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Something went wrong...🤖\nPleast rewrite /getmealinformation , and try again");
                }
                
        }
        }
    }
}
