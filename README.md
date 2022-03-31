# CableSnake

A (very) work-in-progress mod for [Logic World](https://logicworld.net/), focused on cable management and bus interfaces.

## Actually working components

* ThroughInverter - an inverter that mounts through panels, like the through-peg.
* ThroughBlotter - a buffer (1-tick, unconfigurable) that mounts through panels.
* ByteLatch - a fixed size-8 version of the VectorLatch (see below)

## Partially-workingish

* VectorLatch - a variable-sized latch that can latch 1-16 bits in a row.  Unfortunately, we're still working on how to get new component edit dialogs to work on the client; feel free to poke me (Chime) on the LW Discord in the `#modding` channel.

## Intended but not present

* SnakeTerminal - the primary bus interface; will need the part edit dialogs to work usefully, but will allow connecting individual pins to a CableSnake bus, similar to how FlamptX's brilliant [WireBundle](https://github.com/FlamptX/WireBundle) operates, but with different ergonomics:
  * Pins generally directionless, rather than needing separate bundlers and splitters.
  * Terminal size is variable and only represents the local pins, not the total size of the bus.
  * Pins can be numbered (e.g. `input [8:0] addr;`) or have names that can be entered textually and selected by dropdowns (e.g. `clk`).
  * Nestable bundles for easily grouping related sets of functionality, with similarly verilogish interfacing
* Similar panel variants of things that are missing them
* Gendered and structurally complex connectors and socket types for a variety of signal transfer needs
* Parts with integrated socket connection capability
* More panel hardware similar to the switches and buttons, but with more industrial feel and physical details. If it looks like it came out of an Apollo command module, it should probably have a component here.
* A variety of quasi-retro displays, such as flip-card clocks
* Shift register and delay-line memories

## Contributing

* Help is always welcome, be it with devtools, computer/electrical engineering, designs, or code.  Drop in to the Discord and say hi!
* Translation patches are also very welcome, though names are in flux even in English. Likewise, better English names are always welcome too.

## License and Distribution

This is profoundly early-access of a mod for an early-access game that has not yet released a modding infrastructure-- though it looks like it'll be great!  I have nominally flagged my work as BSD 3-Clause for ease of use by others, though portions are written using decompiled code from the game and guides from other modders, so the details may be murky before there is a formally released API.  Hack away though!
