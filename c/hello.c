#include<stdio.h>
int main()
{
    /* First hello world
    in C language
    */
    printf("hello world\n");
    return 0;
}

// Basic Types:

// data type // memory (bytes) // range // format specifier

// arithmetic
// short int // 2 // -32,768 to 32,767 // %hd
// unsigned short int // 2 // 0 to 65,535 // %hu
// unsigned int // 4 // 0 to 4,294,967,295 // %u
// int // 4 // -2,147,483,648 to 2,147,483,647 // %d
// long int // 4 // -2,147,483,648 to 2,147,483,647 // %ld
// unsigned long int // 4 // 0 to 4,294,967,295 // %lu
// long long int // 8 // −9,223,372,036,854,775,807 to +9,223,372,036,854,775,807 // %lli or %lld
// unsigned long long int // 8 // 0 to 18,446,744,073,709,551,615 // %llu

// floating point
// float // 4 // 1.2E-38 to 3.4E+38 // %f // 6 decimal places
// double // 8 // 1.7E-308 to 1.7E+308 // %lf // 15 decimal places
// long double // 16 // 3.4E-4932 to 1.1E+493 // %Lf // 19 decimal places

// signed char // 1 // -128 to 127 // %c
// unsigned char // 1 // 0 to 255 // %c

// ADVICE
// - plan what values your variables will use
//      - optimize memory
//      - prevent errors and memory leaks
// - know how your compiler handle its data types size