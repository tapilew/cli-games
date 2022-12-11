user_option = input("Rock, paper, or scissors => ")
computer_option = "rock"

if user_option == computer_option:
    print("Draw!")
elif user_option == "rock":
    if computer_option == "scissors":
        print("Rock beats scissors")
        print("User wins!")
    else:
        print("Paper beats rock")
        print("Computer wins!")
elif user_option == "paper":
    if computer_option == "rock":
        print("Paper beats rock")
        print("User wins!")
    else:
        print("Scissors beat paper")
        print("Computer wins!")
elif user_option == "scissors":
    if computer_option == "paper":
        print("Scissors beats paper")
        print("User wins!")
    else:
        print("Rock beats scissors")
        print("Computer wins!")
