<template>
  <div id="app">
    <div
      v-for="(quiz, index) in quizez"
      :key="quiz"
      v-show="index === questionindex">
      <h1>{{ quiz.category }}</h1>
      <!-- Questions: display a div for each question -->

      <h2>{{ quiz.question }}</h2>
      <!-- Responses: display a li for each possible response with a radio button -->
      <ol>
        <li v-for="answer in quiz.incorrect_answers" :key="answer">
          <label>
            <input
              type="radio"
              name="answer"
              v-model="answers[index]"
              :value="answer"
            />
            {{ answer }}
          </label>
        </li>
      </ol>
    </div>
    <div v-if="questionindex < quizez.length">
      <button class="btn" v-if="questionindex > 0" v-on:click="prev">
        prev
      </button>
      <button v-on:click="next">
        next
      </button>
    </div>
    <span v-if="questionindex == quizez.length"
      >Your Total score is {{ score }} / {{ quizez.length }}</span
    >
  </div>
</template>

<script>
var quiz_questions = [
  {
    category: "Part V: Incomplete Sentences",
    type: "multiple",
    difficulty: "easy",
    question: "Departmental restructuring will be discussed at the ____ monthly meeting",
    correct_answer: "next",
    incorrect_answers: [
      "next",
      "always",
      "soon",
      "like"
    ]
  },
  {
    category: "Part V: Incomplete Sentences",
    type: "multiple",
    difficulty: "medium",
    question: "To keep ____ park beautiful, please place your nonrecyclables in the available trash cans",
    correct_answer: "our",
    incorrect_answers: ["our", "we", "us", "ours"]
  },
  {
    category: "Part V: Incomplete Sentences",
    type: "multiple",
    difficulty: "easy",
    question: "Mr. Hardin ____ additional images of the office building he is interested in leasing",
    correct_answer: "requested",
    incorrect_answers: ["informed", "asked", "advised", "requested"]
  },
  {
    category: "Part V: Incomplete Sentences",
    type: "multiple",
    difficulty: "hard",
    question: "A team of agricultural experts will be brought ____ to try to improve crop harvests",
    correct_answer: "together",
    incorrect_answers: ["because", "either", "between", "together"]
  },
  {
    category: "Part V: Incomplete Sentences",
    type: "multiple",
    difficulty: "medium",
    question: "The board of Galaxipharm ____ Mr. Kwon's successor at yesterday's meeting",
    correct_answer: "granted",
    incorrect_answers: ["named", "granted", "founded", "proved"]
  },
  {
    category: "Part V: Incomplete Sentences",
    type: "multiple",
    difficulty: "medium",
    question: "If your parking permit is damaged, bring it to the entrance station for a ____",
    correct_answer: "replacement",
    incorrect_answers: [
      "replacement",
      "replacing",
      "replace",
      "replaces"
    ]
  },
  {
    category: "Part V: Incomplete Sentences",
    type: "multiple",
    difficulty: "medium",
    question: "Mr. Ahmad decided to reserve a private room for the awards dinner ____ the restaurant was noisy",
    correct_answer: "in case",
    incorrect_answers: ["rather than", "in case", "such as", "unless"]
  },
  {
    category: "Part V: Incomplete Sentences",
    type: "boolean",
    difficulty: "medium",
    question: "Ms. Jones has provided a ____ estimate of the costs of expanding distribution statewide",
    correct_answer: "conserve",
    incorrect_answers: ["conserve", "conserves","conservative","conservatively"]
  },
  {
    category: "Part V: Incomplete Sentences",
    type: "multiple",
    difficulty: "easy",
    question: "Each quarter, Acaba Exports sets ____ sales goals for its staff",
    correct_answer: "realistic",
    incorrect_answers: [
      "compact",
      "wealthy",
      "faithful",
      "realistic"
    ]
  },
  {
    category: "Part V: Incomplete Sentences",
    type: "multiple",
    difficulty: "medium",
    question: "Ms. Garcia was delighted to receive ____ that her company soon will be featured in the In Town Times magazine",
    correct_answer: "notification",
    incorrect_answers: ["notify", "notifycation",  "notifying",  "notifies"]
  }
];

export default {
  name: "app",
  data: function() {
    return {
      questionindex: 0,
      quizez: quiz_questions,
      answers: Array(quiz_questions.length).fill("")
    };
  },
  methods: {
    // Go to next question
    next: function() {
      this.questionindex++;
    },
    // Go to previous question
    prev: function() {
      this.questionindex--;
    }
  },
  computed: {
    score: function() {
      var total = 0;
      for (var i = 0; i < this.answers.length; i++) {
        if (this.answers[i] == this.quizez[i].correct_answer) {
          total += 1;
        }
      }
      return total;
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin: 100px 120px;
}

button{
	padding: 5px 20px;
	position: right;
}
</style>
