#include <stdio.h>

const char NEW_LINE = '\n';
const int HOTDOG_COST = 100ul; // suffixes for unsigned and long
const float TOTAL_BILL = 100.07;

#define PIZZA_COST 1.5

int main()
{
    float pizzaPrice;
    float numberOfSlices = 3;
    pizzaPrice = PIZZA_COST * numberOfSlices;
    printf("Total bill: %f", pizzaPrice);
    printf("%c", NEW_LINE);

    // C has not string data type
    printf("it's human to fail%c", NEW_LINE); // a string literal
    printf("HOTDOG_COST: %d%c", HOTDOG_COST, NEW_LINE);
    printf("TOTAL_BILL: %f%c", TOTAL_BILL, NEW_LINE);
}