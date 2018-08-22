import { Question } from './QuestionModel';

export const QUESTIONS: Question[] = [
  {
    internalId: '5b5b61c2e7179a07334094e6',
    entityId: 1,
    questionId: 1,
    questionDesc: "Is this the 1st question?",
    questionType: "MultipleChoice",
    choices: [
      "Yelp Search",
      "Our Flyer",
      "From a colleague",
      "Online banner"
    ],
    activeChoice: -1
  },
  {
    internalId: "5b5b62ece7179a073340965e",
    entityId: 1,
    questionId: 2,
    questionDesc: "How often do you go out to eat?",
    questionType: "MultipleChoice",
    choices: [
      "Once in a while",
      "Twice a week",
      "Too often",
      "No comment"
    ],
    activeChoice: -1
  },
  {
    internalId: '5b5b61c2e7179a03434094e6',
    entityId: 1,
    questionId: 3,
    questionDesc: "Did you like the layout of our restaurant?",
    questionType: "MultipleChoice",
    choices: [
      "It's OK",
      "Nicely layed out",
      "Hard to move around",
      "It needs a re-do"
    ],
    activeChoice: -1
  },
  {
    internalId: '5b5b61c2e7179a073340942e',
    entityId: 1,
    questionId: 3,
    questionDesc: "What is your favorite menu item?",
    questionType: "MultipleChoice",
    choices: [
      "Albacore Tuna Salad",
      "Fried Chicken Sandwich",
      "Panini Melt",
      "1/2 Gourmet Sandwich/Soup"
    ],
    activeChoice: -1
  },
];
