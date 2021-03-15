Simple program to yoink kahoot answers from the host id

.Net Core 5 is required.

The program needs the host id, this can be obtained from looking at the hosts screen or if its not a real time kahoot, it's directly on the link

it took about 3 hours to make, that's why it's pretty buggy, altough it works like a charm

Answers are 1-4 (mostly) From LEFT to RIGHT then TOP to BOTTOM

also gives all acceptable answers for writting questions


REALTIME KAHOOT

https://play.kahoot.it/v2/gameblock?quizId=282539c1-6499-48f6-a023-12e97093ee71

The host id from this link is "282539c1-6499-48f6-a023-12e97093ee71"

After this all you have to do is paste the code on the program and it will give you the answers



NON REALTIME KAHOOT

This is when the kahoot can be made at your time and pace, it's also easier to get the answers as you only need to paste the link directly on the program

You need to paste the whole link instead because the answers are stored differently from the realtime one.

https://kahoot.it/challenge/09593226?challenge-id=86902db2-501d-4ac5-af1a-045022e695a6_1615825710479

And you'll get the answers then.



I have encountered a bug where when the answers are images it doesn't manage to get the answer, I am not sure why this is tho.
And there might be other game modes(like quiz, true or false, etc) that I have missed and this will definetly break it, at least for that answer, and it might unsync the question number







All of this works because if you get the host id and place it on 
https://play.kahoot.it/rest/kahoots/(HOST ID)
For real time Kahoot

And https://kahoot.it/rest/challenges/(HOST ID)/answers
For Non real time Kahoot

It will give you all the answers, tho it's pretty hard to read.
Mostly the program is made to parse these answers.

