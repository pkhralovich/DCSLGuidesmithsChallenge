# Technical NET challenge - DCSL GuideSmiths

## Introduction
The target of this challenge is described in the following [page](https://github.com/guidesmiths/interview-code-challenges/blob/master/.NET/martian-robots/instructions.md).

No framework or environment was required. As the original job description was for a .NET engineer, I decided to create a NET Core console application. The system was build using Visual Studio Code 2017 and includes two projects. The first one contains the console application and the second one are the related tests. **The NET Core version is 2.1**.
Inside the test project, I also provide a folder with sample execution files. Each sample has a file with the input, another file with the expected output and the result that I obtained with my application.

**Please, take in account that the input that I generated is slightly different from the described in the requirements, as I print the orientations with the full text (for example, N as North). It's possible to configure the execution to ouput the format described in the requirements.**


## External libraries 

I only used one external library, to parse easily the execution arguments. That library is CommandLineParser (v2.8.0) that is available throught NuGet.

## Shared memory management

For the shared memory management, I decided to create a static property assigned to the Robot object. This property can be of two subtypes of the interface IScent. That allowed me to develop two possible strategies for the lost robots management:

 - **ScentList:** this class uses a list of positions where a robot was lost. The main advantage of that management is that the memory needed to manage the system is quite small because we don't have to build an entire matrix that stores a true/false value for the lost robots. On the other hand, if there are a lot of lost robots, it can be much slower than the other solution.
 - **ScentMatrix**: the main advantage of this system is that the access time is constant, as we only have to read a position of a matrix, without performing a search. On the other hand, it uses more memory than the other solution.

## Application execution

To execute the application, you only have to go to the folder called other/executable and call de MartianRobots.dll.
The way that it should be called is:

    dotnet MartianRobots.dll --instructions <path_to_txt>

The only compulsory param is the --instructions, which must be a path to a file containing the world configuration and the instructions to execute. It's also possible to add two more params:
 - --fast: these param switches between the two memory management systems. If it's present, the application is going to use the Matrix system. Otherwise, the list system is going to be used.
 - --fullFormat: switches between the output of the orientations. If it's present, the orientations are going to be shown as NORTH, otherwise the program will show an N. 

**It's my first time writing and "deploying" a NET Core application, I hope that this is the right way, but maybe there is some problem I wasn't aware of.**

## Class diagram

The class diagram does not contain the Main class, as I think that it's not necessary to understand the arquitecture of the entire project.

![enter image description here](https://raw.githubusercontent.com/pkhralovich/DCSLGuidesmithsChallenge/main/Other/classDiagram.png)

## Patterns
I applied two design pattern to this application, in order to make it easier to add new instructions, as it was written in the requirements. These pattern are:

-  Strategy pattern: allows to customize a behaviour that is stored inside the implementation of an interface. It's the most important part to create new instructions in an easy way. More information: https://refactoring.guru/es/design-patterns/strategy

 - Factory pattern: to create in an easy way the different instructions that I'm going to need. More information: https://www.tutorialspoint.com/design_pattern/factory_pattern.htm

## Easy to extend

I tried to make it easy to add new kinds of planets or instructions to the application. For example, in case that we need a new instruction, we only have to create a new class implementing IInstruction interface and to add a couple of lines of code to the InstructionFactory class. 
In case that we want to add a new Planet, we should add a PlanetFactory class and create a method there that is able to return the appropriate instance depending on the input. The same can be applied for the Robots with a little more work.