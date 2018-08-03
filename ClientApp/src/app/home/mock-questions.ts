import { Question } from './QuestionModel';

export const QUESTIONS: Question[] = [
  {
    internalId: '5b5b61c2e7179a07334094e6',
    entityId: 1,
    questionId: 1,
    questionDesc: "Where did you hear about us?",
    questionType: "MultipleChoice",
    choices: [
      "Yelp Search",
      "Our Flyer",
      "From a colleague",
      "Online banner"
    ]
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
    ]
  }
];
