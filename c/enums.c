#include<stdio.h>

enum weekDays {Sunday = 1, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday};

enum deck {
    club = 0,
    diamonds = 5,
    hearts = 10,
    spades = 15
} card;

int main()
{
    card = spades;
    printf("Card %d\n", sizeof(card));
    enum weekDays today;
    today = Wednesday;
    printf("Day %d", today+1);
    printf("\n");
    return 0;
}