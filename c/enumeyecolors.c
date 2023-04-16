#include<stdio.h>

enum EyeColor {
    Brown,
    Blue = 5,
    Green,
    Gray,
    Heterochromia,
    Other
};

int main()
{
    int userInput;
    scanf("%d", &userInput);
    enum EyeColor myEyeColor;
    myEyeColor = userInput;
    enum EyeColor otherColor = Other;
    printf("%d\n", myEyeColor);
    printf("%d\n", otherColor);
    return 0;
}