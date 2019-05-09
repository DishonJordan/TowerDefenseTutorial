# Tower Movemenet Feature
This feature allows for the level-maker to define movement for the towers, by defining the point the tower will traverse.

## Tower Movement Feature Use:
1. Determine the location your tower will be placed at and whether it will have linear or a 3 point cycle.
2. Create an empty game object and set it's position to the desired location. 

3. Add a sphere collider to the game object with radius 2 and then add either the Linear Tower Placement Area Script or L Tower Area Script. After this, set the layer of the game object to PlacementLayer.

4. Locate the SinglePlacementTile and SinglePlacementTileMobile prefabs, located in the Assets/Prefabs/UI folder, and drag them into the associated "Placement Tile Prefab" and "Placement Tile Prefab Mobile" sections of the Tower Placement Area script added to the game object.

5. Create a empty child gameobject for your tower placement area and move it to the location you want the tower to start at. Drag this game object into the Start position field of the tower placement script.

6. Repeat this process to define the end position of the tower. ( If you are using the L Shaped tower placement area, you will want to define a middle point and drag that into the Middle Position field of the L Tower Placement Area Script).

7. Set the desired speed of the tower, and your tower movement area is now fully functional.
