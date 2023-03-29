using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Write a collection of custom data types in C#. These will implement the required data types (either as structures or classes) and functions listed below.

Your math data types (i.e., structs or classes) must include the following types. The maths operations should be in column-major order, using a right-handed coordinate system, with the following names of types and functions to ensure that your code works correctly with the Unit Test Application used in Assessment Task 2:

Vector3 (3-dimensional vector using 3 floats)
Vector4 (3-dimensional homogeneous vector using 4 floats)
Matrix3 (2-dimensional 3x3 rotation matrix using 9 float)
Matrix4 (3-dimensional 4x4 transform matrix using 16 float)
Colour (RGBA values stored as a 4 byte integer)
Your types must overload the following mathematical operators and include the additionally mentioned member functions, where V represents a Vector, M represents a Matrix, n represents an index and f represents a float:

V = V + V (point translated by a vector)        OVERLOADED OPERATOR
V = V – V (point translated by a vector)        OVERLOADED OPERATOR
V = V x f (vector scale)                        OVERLOADED OPERATOR
V = f x V (vector scale)                        OVERLOADED OPERATOR
V = M x V (vector transformation)               OVERLOADED OPERATOR
M = M x M (matrix concatenation)                OVERLOADED OPERATOR
f = V.Dot( V )                                  METHOD
V = V.Cross( V )                                METHOD
f = V.Magnitude()                               METHOD
Normalize()                                     METHOD
setRotateX( f )                                 METHOD
setRotateY( f ) and                             METHOD
setRotateZ( f )                                 METHOD

If applicable, your types should all have default constructors, and constructors that allow each float element to be set individually, for example:

Vector3 v3; // default
Vector4 v4( 0, 0, 0, 1 );
Matrix3 m3 = Matrix3( 1, 0, 0, 0, 1, 0, 0, 0, 1 );
(Default constructors won't be possible if you are implementing your types as structs, but will be expected if you are writing classes).

Your Color type will have get and set functions/accessors/methods for each colour component that employ bit shifting and bitwise operators to query or modify the individual colour components of the 4 byte integer. For example:

byte Red { get{…} {set{…} }
or, alternatively

byte GetRed();
void SetRed(byte value);

 

Unit Tests
This project contains a series of pre-programmed tests that will validate the implementation of your custom math data types.

To ensure that your code functions correctly, you will use a Unit Test Project to test the accuracy of your mathematical methods in the code you have written for your Maths Data Types.

To demonstrate competency in this subject your custom data types must pass all unit tests provided.



 * Initial understanding:
 * The "custom data types" I have to create will each be a struct, which means I'll be creating 5 structs for this task on top of a header Program class. Initially I planned to use classes, but upon further reading, it became clear this was not the ideal way to implement vectors in C#.
 * 
 * Each struct will have multiple overloaded constructors, because structs do not have default constructors. The parameters have to be able to be set individually (eg x, y and z).
 * 
 * Each Type (struct) must "... implement methods for, in all instances, translation, scale, magnitude, normalisation, cross product and dot product." 
 * 
 *      Does this mean that the head program class needs these 6 methods, and the structs must be able to be passed to them, or that EACH struct needs 6 methods?
 * 
 * 
 * 
 * 
 *  INITIAL PLAN OF PROGRAM LAYOUT
 * 1.0.0.0  Class                       Program


 * 2.1.0.0      Struct                  Vector3     (3 floats)
 * 2.1.0.1          Variable            x   (float) (default automatically-initialised variable for every new struct)
 * 2.1.0.2          Variable            y   (float) (default automatically-initialised variable for every new struct)   
 * 2.1.0.3          Variable            z   (float) (default automatically-initialised variable for every new struct)
 *   
 * 2.1.1.0          Constructor Overload    (3 floats)
 * 2.1.1.1              Variable        _x  (float) (x-axis value to be passed to the constructor, overwrites the default)
 * 2.1.1.2              Variable        _y  (float) (y-axis value to be passed to the constructor, overwrites the default)
 * 2.1.1.3              Variable        _z  (float) (z-axis value to be passed to the constructor, overwrites the default)
 *   
 * 2.1.2.0          Operator overload   +   (Vector3 + Vector3)         TRANSLATION: ADDITION
 * 2.1.3.0          Operator overload   -   (Vector3 - Vector3)         TRANSLATION: SUBTRACTION
 * 2.1.4.0          Operator overload   *   (Vector3 x float)           TRANSFORM: SCALE (float multiplication)
 * 2.1.5.0          Operator overload   *   (float x Vector3)           TRANSFORM: SCALE (float multiplication)
 * 2.1.6.0          Operator overload   /   (Vector3 / float)           TRANSFORM: SCALE (float division)
 * 2.1.7.0          Operator overload   /   (float / Vector3)           TRANSFORM: SCALE (float division)
 * 
 * 2.2.0.0     Method (return float)        Dot(Vector3)
 * 2.3.0.0     Method (return Vector3)      Cross(Vector3)
 * 2.4.0.0     Method (void)                Magnitude()
 * 2.5.0.0     Method (void)                Normalize()


 * 3.1.0.0      Struct                  Vector4     (4 floats)
 * 3.1.0.1          Variable            x   (float) (default automatically-initialised variable for every new struct)
 * 3.1.0.2          Variable            y   (float) (default automatically-initialised variable for every new struct)   
 * 3.1.0.3          Variable            z   (float) (default automatically-initialised variable for every new struct)
 * 3.1.0.3          Variable            w   (float) (default automatically-initialised variable for every new struct)
 *  
 * 3.1.1.0          Constructor Overload    (4 floats)
 * 3.1.1.1              Variable        _x  (float) (x-axis value to be passed to the constructor, overwrites the default)
 * 3.1.1.2              Variable        _y  (float) (y-axis value to be passed to the constructor, overwrites the default)
 * 3.1.1.3              Variable        _z  (float) (z-axis value to be passed to the constructor, overwrites the default)
 * 3.1.1.3              Variable        _w  (float) (w-axis value to be passed to the constructor, overwrites the default)
 *  
 * 3.1.2.0          Operator overload   +   (Vector4 + Vector4)         ADDITION
 * 3.1.3.0          Operator overload   -   (Vector4 - Vector4)         SUBTRACTION
 * 3.1.4.0          Operator overload   *   (Vector4 x float)           TRANSFORM: SCALE (float multiplication)
 * 3.1.5.0          Operator overload   *   (float x Vector4)           TRANSFORM: SCALE (float multiplication)
 * 3.1.6.0          Operator overload   /   (Vector4 / float)           TRANSFORM: SCALE (float division)
 * 3.1.7.0          Operator overload   /   (float / Vector4)           TRANSFORM: SCALE (float division)
 * 3.1.8.0          Operator overload   *   (Vector4 * Matrix4)         TRANSFORM: SCALE (vector multiplication)
 * 
 * 3.2.0.0     Method (return float)        V.Dot(Vector4)
 * 3.3.0.0     Method (return Vector4)      V.Cross(Vector4)
 * 3.4.0.0     Method (void)                V.Magnitude()
 * 3.5.0.0     Method (void)                Normalize()


 * 4.1.0.0      Struct                  Matrix3   (2-dimensional 3x3 rotation matrix using 9 float)
 * 4.1.0.1          Variable            m00 (float) (default automatically-initialised variable for every new struct)
 * 4.1.0.2          Variable            m01 (float) (default automatically-initialised variable for every new struct)
 * 4.1.0.3          Variable            m02 (float) (default automatically-initialised variable for every new struct)
 * 4.1.0.4          Variable            m10 (float) (default automatically-initialised variable for every new struct)
 * 4.1.0.5          Variable            m11 (float) (default automatically-initialised variable for every new struct)
 * 4.1.0.6          Variable            m12 (float) (default automatically-initialised variable for every new struct)
 * 4.1.0.7          Variable            m20 (float) (default automatically-initialised variable for every new struct)
 * 4.1.0.8          Variable            m21 (float) (default automatically-initialised variable for every new struct)
 * 4.1.0.9          Variable            m22 (float) (default automatically-initialised variable for every new struct)
 * 
 * 4.1.1.0          Constructor Overload (9 floats)
 * 4.1.1.1              Variable        _m00 (float) // (Vector A x-axis value to be passed to the constructor, overwrites the default)
 * 4.1.1.2              Variable        _m01 (float) // (Vector B x-axis value to be passed to the constructor, overwrites the default)
 * 4.1.1.3              Variable        _m02 (float) // (Vector C x-axis value to be passed to the constructor, overwrites the default)
 * 4.1.1.4              Variable        _m10 (float) // (Vector A y-axis value to be passed to the constructor, overwrites the default)
 * 4.1.1.5              Variable        _m11 (float) // (Vector B y-axis value to be passed to the constructor, overwrites the default)
 * 4.1.1.6              Variable        _m12 (float) // (Vector C y-axis value to be passed to the constructor, overwrites the default)
 * 4.1.1.7              Variable        _m20 (float) // (Vector A z-axis value to be passed to the constructor, overwrites the default)
 * 4.1.1.8              Variable        _m21 (float) // (Vector B z-axis value to be passed to the constructor, overwrites the default)
 * 4.1.1.9              Variable        _m22 (float) // (Vector C z-axis value to be passed to the constructor, overwrites the default)
 * 
 * 4.1.2.0          Operator overload   *   (Matrix3 * Vector3)         TRANSFORM: SCALE (vector multiplication)
 * 4.1.3.0          Operator overload   *   (Matrix3 * Matrix3)         TRANSFORM: SCALE (matrix multiplication)
 * 
 * 4.2.0.0      Method (void)           setRotateX(1 float)
 * 4.3.0.0      Method (void)           setRotateY(1 float)
 * 4.4.0.0      Method (void)           setRotateZ(1 float)
 * 4.5.0.0      Method (void)           TransposeMatrix(Matrix3)

 * 5.1.0.0      Struct       Matrix4   (3-dimensional 4x4 transform matrix using 16 float)
 * 5.1.0.1          Variable            m00 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.2          Variable            m01 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.3          Variable            m02 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.4          Variable            m03 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.5          Variable            m10 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.6          Variable            m11 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.7          Variable            m12 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.8          Variable            m13 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.9          Variable            m20 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.10         Variable            m21 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.11         Variable            m22 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.12         Variable            m23 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.13         Variable            m30 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.14         Variable            m31 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.15         Variable            m32 (float)  (default automatically-initialised variable for every new struct) 
 * 5.1.0.16         Variable            m33 (float)  (default automatically-initialised variable for every new struct) 
 * 
 * 5.1.1.0          Constructor Overload (16 floats)
 * 5.1.1.1              Variable        _m00 (float) (Vector A x-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.2              Variable        _m01 (float) (Vector A y-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.3              Variable        _m02 (float) (Vector A z-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.4              Variable        _m03 (float) (Vector A w-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.5              Variable        _m10 (float) (Vector B x-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.6              Variable        _m11 (float) (Vector B y-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.7              Variable        _m12 (float) (Vector B z-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.8              Variable        _m13 (float) (Vector B w-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.9              Variable        _m20 (float) (Vector C x-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.10             Variable        _m21 (float) (Vector C y-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.11             Variable        _m22 (float) (Vector C z-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.12             Variable        _m23 (float) (Vector C w-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.13             Variable        _m30 (float) (Vector D x-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.14             Variable        _m31 (float) (Vector D y-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.15             Variable        _m32 (float) (Vector D z-axis value to be passed to the constructor, overwrites the default)
 * 5.1.1.16             Variable        _m33 (float) (Vector D w-axis value to be passed to the constructor, overwrites the default)
 * 
 * 5.1.2.0          Operator overload   *   (Matrix4 * Vector4)         TRANSFORM: SCALE (vector multiplication)
 * 5.1.3.0          Operator overload   *   (Matrix4 * Matrix4)         TRANSFORM: SCALE (matrix multiplication)
 * 
 * 5.2.0.0      Method (void)           setRotateX(1 float)
 * 5.3.0.0      Method (void)           setRotateY(1 float)
 * 5.4.0.0      Method (void)           setRotateZ(1 float)
 * 5.5.0.0      Method (void)           TransposeMatrix(Matrix4)
 * 
 * 
 * 6.0.0.0      Class       Colour    (RGBA values stored as a 4 byte integer)
 * 6.1.0.0      Constructor Default
 * 6.2.0.0      Constructor Overload (4 byte integer)
 * 
 *
 */

namespace MFG_Task_1
{
    internal class Program
    {
        // header information about the assessment
        public string studentIntroduction =
            "Game Programming Year 1 - CUA51020/ICT50220 - CAN - 2023\n" +
            "Maths for Games \n" +
            "Assessment Task 1 - Custom Data Types\n" +
            "Competency: PGDMTH6005\t\tApply fundamental games programming mathematics skills\n" +
            "Competency: CUADIG511\t\tCoordinate testing of interactive media products\n" +
            "Student name (Last, First): Kerr, Zora\n" +
            "Student ID: (s220780)\n\n\n" +
            "Criteria 1. Vector types for 3D vectors\n" +
            "\tWrite Vector data types for 3D vectors, including homogeneous 3D vectors. Types implement methods for, in all instances, translation, scale, magnitude, normalisation, cross product and dot product. All written code conforms to the provided brief (in Instructions to Students)\n\n" +
            "Criteria 2. Matrix types for 3D matrices\n" +
            "\tWrite Matrix data types for 3D matrices, including homogeneous 4D matrices. Types implement methods for multiplication, vectors transformation, and transpose. Types implement methods for setting up as rotation matrices. All written code conforms to the provided brief (in Instructions to Students).\n\n" +
            "Critera 3. Color type\n" +
            "\tWrite a Color data type. As part of the Color type, functions for manipulating a bitfield implemented using bit shift operations All written code conforms to the provided brief (in Instructions to Students).\n\n" +
            "Criteria 4. Unit Testing\n" +
            "\tCustom maths data types have been imported into the unit testing project. All custom maths data types pass all unit tests in the provided Unit Testing Project.\n\n";

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.studentIntroduction);
            Console.ReadLine();
        }
            
    }
}
