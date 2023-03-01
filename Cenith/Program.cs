// Give world size as comma separated array of types
// Give array dimensions to create world

using Cenith;
using Cenith.Services;

const int x = 3;
const int y = 3;

// Default test world
var worldInput = new []
{
    "mud",
    "blank",
    "mud",
    "lava",
    "lava",
    "blank",
    "speeder",
    "blank",
    "mud",
};

// Loop through each input and add to array


var world = WorldFactory.BuildWorld(x, y, worldInput);

var routes = new SearchService().Calculate(world, world[0,0], world[2,2]);

routes.PrintLegs();






