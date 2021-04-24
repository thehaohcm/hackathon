<template>
  <div id="question">
	  <RemainingTimer />
    <div
      v-for="(quiz, index) in quizez"
      :key="quiz"
      v-show="index === questionindex">
      <h1>{{ quiz.category }}</h1>

      <h2>{{ quiz.question }}</h2>
      <ol type="A">
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
    <div class="btns" v-if="questionindex < quizez.length">
      <button class="btn prev" v-if="questionindex > 0" v-on:click="prev">
        prev
      </button>
      <button class="btn next" v-on:click="next">
        next
      </button>
    </div>
    <span v-if="questionindex == quizez.length"
      >Your Total score is {{ score }} / {{ quizez.length }}
	</span>
  </div>
</template>

<script>
import RemainingTimer from './RemainingTimer'

export default {
	components:{
		RemainingTimer
	},
	name: "question",
	data: function() {
		return {
			questionindex: 0,
			quizez: this.$store.state.questions,
			answers: Array(this.$store.state.questions).fill("")
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
#question {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

button{
	padding: 10px 20px;
	position: right;
}

.btns{
	width: 100%;
}

input[type=radio] {
	padding: 10pt;
    font-size: 10pt;
}
</style>
