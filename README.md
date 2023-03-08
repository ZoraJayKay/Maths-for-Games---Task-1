# Maths for Games - Task 1
## Assessment Task 1 - Custom Data Types

Write a collection of custom data types in C#. These will implement the required data types (either as structures or classes) and functions listed below.

Your math data types (i.e., structs or classes) must include the following types. The maths operations should be in column-major order, using a right-handed coordinate system, with the following names of types and functions to ensure that your code works correctly with the Unit Test Application used in Assessment Task 2:

* Vector3 (3-dimensional vector using 3 floats)
* Vector4 (3-dimensional homogeneous vector using 4 floats)
* Matrix3 (2-dimensional 3x3 rotation matrix using 9 float)
* Matrix4 (3-dimensional 4x4 transform matrix using 16 float)
* Colour (RGBA values stored as a 4 byte integer)


Your types must overload the following mathematical operators and include the additionally mentioned member functions, where V represents a Vector, M represents a Matrix, n represents an index and f represents a float:

* V = V + V (point translated by a vector)
* V = V – V (point translated by a vector)
* V = V x f (vector scale)
* V = f x V (vector scale)
* V = M x V (vector transformation)
* M = M x M (matrix concatenation)
* f = V.Dot( V )
* V = V.Cross( V )
* f = V.Magnitude()
* Normalize()
* setRotateX( f )
* setRotateY( f ) and
* setRotateZ( f )


If applicable, your types should all have default constructors, and constructors that allow each float element to be set individually, for example:

* Vector3 v3; // default
* Vector4 v4( 0, 0, 0, 1 );
* Matrix3 m3 = Matrix3( 1, 0, 0, 0, 1, 0, 0, 0, 1 );

(Default constructors won't be possible if you are implementing your types as structs, but will be expected if you are writing classes).


Your Color type will have get and set functions/accessors/methods for each colour component that employ bit shifting and bitwise operators to query or modify the individual colour components of the 4 byte integer. For example:

* byte Red { get{…} {set{…} }

or, alternatively

* byte GetRed();

void SetRed(byte value);


This project contains a series of pre-programmed tests that will validate the implementation of your custom math data types.

To ensure that your code functions correctly, you will use a Unit Test Project to test the accuracy of your mathematical methods in the code you have written for your Maths Data Types.

To demonstrate competency in this subject your custom data types must pass all unit tests provided.
