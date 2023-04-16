#include <stdio.h>
int main()
{
    const char newLine = '\n';
    // C has not string data type
    printf("it's human to fail%c", newLine); // a string literal
    const int hotDogPrice = 100ul; // suffixes for unsigned and long
    printf("hotDogPrice: %d%c", hotDogPrice, newLine);
    const float totalBill = 100.07;
    printf("totalBill: %f%c", totalBill, newLine);
}