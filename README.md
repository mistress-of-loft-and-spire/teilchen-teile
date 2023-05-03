
![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/pic02.png)
![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/pic01.png)
![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/pic03.png)

<a href="https://www.youtube.com/watch?feature=player_embedded&v=1IZpQnlsf40
" target="_blank"><img src="https://img.youtube.com/vi/1IZpQnlsf40/0.jpg" 
alt="video" width="1280" /></a>  
[https://www.youtube.com/watch?v=1IZpQnlsf40](https://www.youtube.com/watch?v=1IZpQnlsf40)

</br></br></br></br></br></br></br></br></br></br></br></br></br></br>

teilchen/teile  
manual  

</br></br></br></br></br></br></br></br></br></br></br></br></br></br>


## Index

</br>

    |          Overview
    ||         Installation example
    |||        Physical setup instructions
    ||||       Digital setup instructions
    |||||      Troubleshooting
    ||||||     Addendum

</br></br></br></br>

## I Overview

</br>

The teilchen/teile sculpture installation consists of the following pieces:  

    32 steel wires (4m length, 1mm diameter,  1x19 braid)
	32 insulated copper cables
	8 connector wires and 1 alligator clip
	Makey Makey Classic connector board 
    
	Computer for running the teilchen/teile program
    	(see addendum for recommended specs)
	HDMI projector
	Audio speakers
	
    A copy of the teilchen/teile program (.exe or .app)
	    (you need to build and compile this yourself,
        see the project-files folder and contained readme.md files)
	
    As well as some electrical connectors, screws and device cables
	    (see physical setup instructions for details)
		
</br>

The following equipment is recommended for setting up the installation:

    Screwdriver and drill
	Soldering iron and optionally a multimeter
	Mouse and keyboard
	 
</br></br></br></br>

## II Installation example

</br>
        
The following is an example of a possible setup for teilchen/ teile. The schemes show the configuration as it was during the Eisen (2018) sculpture exhibition in Bredelar.  

![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/1.png)

</br></br>

![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/1b.png)

![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/2.png)
 
</br></br></br></br>

## III Physical setup instructions

</br>

Plan out the equipment setup as shown on the previous pages.  

The projector should have enough distance for a wide projection (at least 2.5 meters width). The projection light may pass through the steel wires. The sound speakers may be loud enough to allow for a pleasing vibration at low frequencies.  

The Makey Makey may be positioned centrally above the steel wires, or slightly to the front. In the Eisen (2018) exhibition this was achieved by hanging it from inside a chandelier.  

Device cables should follow cozily along the walls.  

The room may be dimmed at will, plastic blankets are recommended for this.  

</br></br>

You will need the following materials for the next steps.  
(Note the shading of each different type of connector)  

![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/3.png)

</br></br>

Next up, you will have to lay out and attach the steel wires.  

During Eisen (2018) the wires were layed out in a 8x4 grid as shown below. Each wire 40cm apart from one another.  

Take note that there are two different types of wire in this arrangement: 16 input signal wires (here shown in black) and 16 grounding wires (here shown striped).  

![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/4.png)

The Makey Makey only receives inputs when an input signal wire connects with a ground wire.  

Ground-ground or input-input touching will sadly not produce an input signal (Although multiple connections with at least one ground and one signal will).  

Therefore the wires have been layed out in this alternating checkerboard pattern.  

Except for the connection on the Makey Makey, there is no difference in material between input and ground wires.  

</br></br>

In order to allow for all of the functions of the teilchen/teile program, the Makey Makey connects 8 different key signal inputs. Each connected to 2 steel input wires respectively.  

The input signals are:  

    W
	A
	S
	D
	F
	G
	left mouse button (l.m.)
	right mouse button (r.m.)

Therefore the final layout of the steel wires was as follows:  

![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/4b.png)

</br></br>

Once you have properly layed out the wire positions, you may attach the wires on the ceiling as follows.  

Note that the copper cables should already be soldered to the ends of the steel wire before mounting. The cables will be connected to the Makey Makey in the next step, leave them carefully dangling for now.  

![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/5.png)

Make sure the steel wire holds firmly in place, even when pulling on it a little.  

</br></br>

Finally you will now connect each of the copper cables -- via the white connector wires -- to the Makey Makey, as shown on the next pages.  

There should be a push-in connector for each key input, labled accordingly. As well as a ground push-in connector for the 16 ground wires.  

Remember to look back to the connector type overview and the steel wire layout for more context.  

![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/6.png)

Let's take the W connection as an example:  

First, plug in the white connector wire into the W input on the Makey Makey.  

Plug the other end into the W connector.  

Plug in the 2 copper cables corresponding to the W steel signal wires into the connector as well.  

Repeat this process for all 8 inputs, as well as the grounding connector. Note that the ground connector is linked via an alligator clip.  

![](https://raw.githubusercontent.com/voec/teilchen-teile/master/manual/6b.png)

You should now be able to make a connection from one steel wire all the way through the Makey Makey to a grounding steel wire.  

Remember to check if all inputs are working correctly!
 
</br></br></br></br>

## IIII Digital setup instructions

</br>

Copy the teilchen/teile program onto the computer.  

Run the .exe or .app file. Select fullscreen mode and set the display resolution if prompted.  

Disconnect all input devices other than the Makey Makey. The installation should now be running.

</br></br></br></br>

## IIIII Troubleshooting

</br>

**The teilchen/teile program is running at a low framerate or not starting at all...**

Check that your device is meeting the recommended system specs.  

Try lowering the graphics settings in the startup configuration popup (Hold the ALT key during launch).  

Install any necessary drivers or redistributables. Try installing and running Unity Engine to check that you have all required files and other projects are working.  

</br>

**I am touching/connecting the steel wires but the visuals and sound do not change or react properly...**

Make sure the teilchen/teile program is focused so it can receive inputs. Click into the program window once.  

Make sure the Makey Makey is connected and the status LED is showing a signal. Try plugging the Makey Makey out and in again.  

Make sure you are connecting a grounding and input wire respectively.
Check that all soldering and clip connections are in order (using a multimeter can help here).  

</br>

**I am not touching any wires but the Makey Makey/program is still receiving inputs...**

Make sure that no wires are entangled with each other.  

Make sure that no other input devices are plugged in. Try plugging the Makey Makey out and in again.  

Check that all soldering and clip connections are in order (using a multimeter can help here). Check that no two connectors are accidentally touching on the Makey Makey.  

Check that all insulation is in order. Occasionally humid conditions/surfaces can cause short circuits. If the wires are hung from screws in the ceiling, use plastic dowels to minimize the risk of false connections through humid plaster or conductive materials in the ceiling.

</br>

**Check the Makey Makey manual for further help.**

</br></br></br></br>

## IIIIII Addendum

</br>

**Recommended minimum system specs**

    2,4 GHz Intel Core 2 Duo Prozessor
	8 GB DDR3 RAM
	50 GB HDD
	NVIDIA GeForce 320M, 256 MB DDR3
	USB Connector Type A
	
    tested on Mac OS X 10.9.5 and Windows 10, 64bit
    
    built using Unity version 2018.1.1f1 (64bit)

</br></br></br></br></br></br></br></br></br></br></br></br></br></br>

many thanks to julia for  
co-producing the installation with me

this manual was written by nicole  
and is licensed under the MIT License  

version 1.3

teilchen/teile, 2018

</br></br></br></br></br></br></br></br></br></br></br></br></br></br>
