# [ParkingLot](https://github.com/rahulchrty/ParkingLot.git)

A parking lot tickting tool

## Require Tools to build and run

Windows 7 or above

Visual Studio 2015 or above

.Net 4.5 or above

## Commands and outputs

* Application can run either by providing a file parameter  `ParkingLot file.txt`.
* Or just by typing `ParkingLot` to command prompt and then provide require commands

### Sample inputs `d:\>ParkingLot d:\files\parking.txt`

```bash 
create_parking_lot 6
park KA-01-HH-1234 White
park KA-01-HH-9999 White
park KA-01-BB-0001 Black
park KA-01-HH-7777 Red
park KA-01-HH-2701 Blue
park KA-01-HH-3141 Black
leave 4
status
park KA-01-P-333 White
park DL-12-AA-9999 White
registration_numbers_for_cars_with_colour White
slot_numbers_for_cars_with_colour White
slot_number_for_registration_number KA-01-HH-3141
slot_number_for_registration_number MH-04-AY-1111
```

### Sample Output
```bash
Created a parking lot with 6 slots
Allocated slot number: 1
Allocated slot number: 2
Allocated slot number: 3
Allocated slot number: 4
Allocated slot number: 5
Allocated slot number: 6
Slot number 4 is free
Slot No. Registration No Colour
1 KA-01-HH-1234 White
2 KA-01-HH-9999 White
3 KA-01-BB-0001 Black
5 KA-01-HH-2701 Blue
6 KA-01-HH-3141 Black
Allocated slot number: 4
Sorry, parking lot is full
KA-01-HH-1234, KA-01-HH-9999, KA-01-P-333
1, 2, 4
6
Not found
```

### `d:\>ParkingLot`
```bash
create_parking_lot 6
Created a parking lot with 6 slots
park KA-01-HH-1234 White
Allocated slot number: 1
park KA-01-HH-9999 White
Allocated slot number: 2
park KA-01-BB-0001 Black
Allocated slot number: 3
park KA-01-HH-7777 Red
Allocated slot number: 4
park KA-01-HH-2701 Blue
Allocated slot number: 5
park KA-01-HH-3141 Black
Allocated slot number: 6
leave 4
Slot number 4 is free
status
Slot No. Registration No Colour
1 KA-01-HH-1234 White
2 KA-01-HH-9999 White
3 KA-01-BB-0001 Black
5 KA-01-HH-2701 Blue
6 KA-01-HH-3141 Black
park KA-01-P-333 White
Allocated slot number: 4
park DL-12-AA-9999 White
Sorry, parking lot is full
registration_numbers_for_cars_with_colour White
KA-01-HH-1234, KA-01-HH-9999, KA-01-P-333
slot_numbers_for_cars_with_colour White
1, 2, 4
slot_number_for_registration_number KA-01-HH-3141
6
slot_number_for_registration_number MH-04-AY-1111
Not found
exit
```