using BattleShip.API;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
BatailleNavale[] grilles = { };
List<string> shotByIa = new List<string>();
int toucheCount = 0 ;
int toucheIaCount = 0;
string winner = "_NONE_";

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/start", () =>
{
    shotByIa.Clear();
    toucheCount = 0 ;
    toucheIaCount = 0 ;
    grilles = new BatailleNavale[] { new BatailleNavale(), new BatailleNavale() };
    return TypedResults.Ok(
        grilles
        );
});

app.MapGet("/atk/{x}/{y}/ia", ([FromRoute] string x, [FromRoute] string y) =>
{
    /*grilles contient les 2 grilles
    *[0] donne celle du joueur et [1] de l'ia
    *positionsBateaux r�cupere tous ce qu'il y a dedans
    *[0] acc�de � la 1er it�ration mais on doit indiquer le nom de bateau quand m�me parce que cest une liste de 1 avec une liste dedans
    *[bateau-LETTRE] nom du bateau
    *[0] la premiere coord du bateau
    *coord est partag� en 2 une lettre et un chiffre LETTRE = x et chiffre = y
    */
    var touche = false;

    foreach (var bateau in grilles[1].PositionsBateaux)
    {
        // Chaque �l�ment dans PositionsBateaux 
        foreach (var e in bateau)
        {
            string nomBateau = e.Key;
            List<string> positions = e.Value;

            Console.WriteLine($"Bateau: {nomBateau}");

            foreach (var coord in positions)
            {
                if (coord == x + y)
                {
                    touche = true;
                }
                Console.WriteLine($"  Coordonn�e: {coord}");
            }
        }
    }


    Console.WriteLine(x);
    Console.WriteLine(y);
    var positionsBateaux = grilles[0].PositionsBateaux;
    Console.WriteLine(positionsBateaux[0]["bateau-A"][0]);



    string[] xCoord = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j"];
    var isAlreadyShot = false;
    do
    {
        isAlreadyShot = false;

        var yCoord = Random.Shared.Next(10);
        var xIndex = Random.Shared.Next(xCoord.Length);
        foreach (var e in shotByIa)
        {
            if (e == (xCoord[xIndex] + yCoord))
            {
                isAlreadyShot = true;
            }
            Console.WriteLine(e + " / " + xCoord[xIndex] + yCoord + " / " + isAlreadyShot);
        }
        if (!isAlreadyShot)
        {
            shotByIa.Add(xCoord[xIndex] + yCoord);
        }
        Console.WriteLine("next-------------------------");
    } while (isAlreadyShot);
    var toucheIa = false;

    foreach (var bateau in grilles[0].PositionsBateaux)
    {

        foreach (var e in bateau)
        {
            string nomBateau = e.Key;
            List<string> positions = e.Value;

            Console.WriteLine($"Bateau: {nomBateau}");


            foreach (var coord in positions)
            {
                if (coord == shotByIa[shotByIa.Count() - 1])
                {
                    toucheIa = true;
                }
                Console.WriteLine($"  Coordonn�e: {coord}");
            }
        }
    }
    if (touche){
        toucheCount ++ ;
    }
    if (toucheIa){
        toucheIaCount ++;
    }

    if (toucheCount == 15 ){
        winner = "_PLAYER_";
    }else if(toucheIaCount == 15 ){
        winner = "_IA_";
    }
    return TypedResults.Ok(new { touche, toucheIa, shotByIa, winner });

});

app.MapGet("/atkIa", () =>
{
    string[] xCoord = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j"];
    var isAlreadyShot = false;
    do
    {
        isAlreadyShot = false;

        var yCoord = Random.Shared.Next(10);
        var xIndex = Random.Shared.Next(xCoord.Length);
        foreach (var e in shotByIa)
        {
            if (e == (xCoord[xIndex] + yCoord))
            {
                isAlreadyShot = true;
            }
            Console.WriteLine(e + " / " + xCoord[xIndex] + yCoord + " / " + isAlreadyShot);
        }
        if (!isAlreadyShot)
        {
            shotByIa.Add(xCoord[xIndex] + yCoord);
        }
        Console.WriteLine("next-------------------------");
    } while (isAlreadyShot);
    var toucheIa = false;

    foreach (var bateau in grilles[0].PositionsBateaux)
    {

        foreach (var e in bateau)
        {
            string nomBateau = e.Key;
            List<string> positions = e.Value;

            Console.WriteLine($"Bateau: {nomBateau}");


            foreach (var coord in positions)
            {
                if (coord == shotByIa[shotByIa.Count() - 1])
                {
                    toucheIa = true;
                }
                Console.WriteLine($"  Coordonn�e: {coord}");
            }
        }
    }
    return TypedResults.Ok(new { toucheIa, shotByIa });

});


app.Run();
