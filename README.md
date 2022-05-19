Design assumptions:
Simulation of gameplay of 2 players.
Needed:
2 boards
2 set of ships
Backend:
Algorithm:
Create boards
create lists of ships
place ships on board
start simulation
Simulation:
one player has one shot per round. Shots are fired after 1s delay every round. After all ships of one player are destroyed, end the game.
Frontend:
send start request
receive data in intervals.
process data
show data

Create game simulation:
Create a game service that processes simulation.
Create a game repository that contains data for simulation.
Repository contain boards and ship lists.
Create boards:
Create a board service that processes boards.
Take an empty board and fill it with empty fields.
Create list of ships:
Create a ship class defining a single ship.
Constructor takes the name, symbol and lives of the ship.
Create a game service that has methods to process data.
In repository create list of ships with needed vessels (carrier, battleship, destroyer, submarine and patrol boat)
Try to place ships on board based on game rules(no interference of one pool between ships, all of the ships placed in one row or col not between them.
If rules are not broken, place the ship on the game board, changing fields to ship symbols.
After all ships are placed, start simulation.
In simulation, shot at a random place on the game board. Next steps are delayed by 1s. If the hit field is empty, change its value to missed. If a ship is hit, change the field to hit and register it, reducing the ship's hp. After all lives are lost, the ship is destroyed. Message of every shot result is stored in an events table. After every shot check the list of destroyed ships, if it contains all ones player ships, signal true. The player with the remaining ships wins.
All boards and events data is stored in the game repository. 

Frontend side calls the method starting simulation. Next it calls for data every second. It stores it in arrays and maps them to show rectangles of the board in the right color depending on received data. 
