// ============================================================================
// Ahoy, matey! Welcome aboard the PirateSalute, a wee program that greets
// every scallywag who dares to type their name into the console. Arrr!
// ============================================================================

// Hoist the colors and ask the swabbie for their name.
Console.Write("What be yer name, sailor? ");
string? name = Console.ReadLine();

// Blimey! Give the brave soul a proper pirate salute.
Salute(name);

// Yarr! This here be the salute function — small, sharp, and to the point.
static void Salute(string? name)
{
    // Shiver me timbers! If no name be given, we call 'em "stranger".
    string greeting = string.IsNullOrWhiteSpace(name) ? "stranger" : name.Trim();
    Console.WriteLine($"Ahoy, {greeting}, lets get to work mate!");
}

