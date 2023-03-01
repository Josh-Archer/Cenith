# Cenith
## Approach
I decided to use Dijkstra's algorithm for this project. There are more efficient and better algorithms - A*, for example. I haven't used some of them in a long time, so
I went with Dijkstra to evaluate each neighbor and find the quickest path using a weighted Health + Move. I used the Program class/Main method more as a run example.
I built it so any UI could be used on it. I built example Factory too. If other input types (other than the existing string array) to define the 2D array would be desired,
we simply need to add an overload. I made the assumption that this would be standard array and not jagged array based on the prompt. The other assumption I made was regarding
starting health/moves. It seemed in the prompt that limitation was driven towards to UI version. In non-demo environment, I would confirm all these with product team.

## Improvments
To keep time in mind, and with the understanding this is just to give you an idea on how I think, I decided to take some short cuts. I will call these out here and speak
on improvments I would make. 

  1. **More unit test**: I shorted the unit tests in regards to time. I did some very basic tests to show how I would approach tests. Unit tests are crucial to good development.
  2. **Dependency Injection**: I would of used a DI container to register my services and set the project up for further success/expansion. This would of made my unit testing
  cleaner/easier.
  3. **Not throw exceptions**: Exceptions are costly to throw. I prefer to handle in a cleaner way/more functional programming way. If exceptions are a must, I would not use
  basic `Exception`. I would of defined custom exceptions that I could reuse in the project. 
