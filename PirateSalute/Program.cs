// ============================================================================
// Ahoy, matey! Welcome aboard the PirateSalute, a wee program that greets
// every scallywag who dares to type their name into the console. Arrr!
// ============================================================================

// Hoist the colors and ask the swabbie for their name.
Console.Write("What be yer name, sailor? ");
string? name = Console.ReadLine();

// Blimey! Give the brave soul a proper pirate salute.
Salute(name);

// Avast! Now we parley with the new recruit and see what skills they bring aboard.
AskWhatYeCanDo();

// Yarr! This here be the salute function — small, sharp, and to the point.
static void Salute(string? name)
{
    // Shiver me timbers! If no name be given, we call 'em "stranger".
    string greeting = string.IsNullOrWhiteSpace(name) ? "stranger" : name.Trim();
    Console.WriteLine($"Ahoy, {greeting}, lets get to work mate!");
}

// Arrr! Roll out the recruitment manifest and let the swabbie pick their poison.
static void AskWhatYeCanDo()
{
    // Hoist the question flag high so every bilge rat can read it.
    Console.WriteLine();
    Console.WriteLine("What can ye do?");

    // These be the five noble trades aboard this here vessel — pick wisely, matey!
    Console.WriteLine($"  1. {PirateText.OptionRum}");
    Console.WriteLine($"  2. {PirateText.OptionTreasure}");
    Console.WriteLine($"  3. {PirateText.OptionCook}");
    Console.WriteLine($"  4. {PirateText.OptionSwab}");
    Console.WriteLine($"  5. {PirateText.OptionNavigate}");

    // Prompt the scallywag fer their choice — one digit be all we need.
    Console.Write("Yer pick (1-5), matey: ");
    string? choice = Console.ReadLine()?.Trim();

    // Hoist the matchin' reply from the pirate's locker.
    string response = choice switch
    {
        "1" => PirateText.ResponseRum,
        "2" => PirateText.ResponseTreasure,
        "3" => PirateText.ResponseCook,
        "4" => PirateText.ResponseSwab,
        "5" => PirateText.ResponseNavigate,
        _   => PirateText.ResponseInvalid
    };

    // Bellow the response across the deck fer all to hear.
    Console.WriteLine(response);
}

