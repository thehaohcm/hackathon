<template>
  <div id="question">
	  <RemainingTimer />
    <div v-for="(part, index_part) in parts" :key="index_part">
      <h1>Part {{part.partNumber}}: {{ part.partName }}</h1>
		<br/>
      <!-- <h2>{{ part.question }}</h2> -->
      <!-- <ol type="A">
        <li v-for="(answer, index_answer) in quiz.incorrect_answers" :key="index_answer">
          <label>
            <input type="radio" name="answer" v-model="answers[index_answer]" :value="answer" v-on:change="answerQuestion(index_quiz, index_answer,answer)"/>
            {{ answer }}
          </label>
        </li>
      </ol> -->

	  <div v-for="(quesItem, index_ques) in part.items" :key="index_ques">
		  <div v-for="(contentItem, index_content) in quesItem.content" :key="index_content">
			  <div v-if="contentItem.type=='audio'">
				<audio controls :src="contentItem.source" type="audio/mp3" controlsList="nodownload"></audio>
				<br />
			  </div>
			  <div v-if="contentItem.type=='image'">
				<img :src="contentItem.source"/>
				<br />
			  </div>
			  <div v-if="contentItem.type=='text'">
				  <p>{{contentItem.source}}</p>
				  <br />
			  </div>
		  </div>
		  <div v-for="(question, index_question) in quesItem.questions" :key="index_question">
			  <h4 class="question">Question {{question.id}}.&emsp;{{question.question}}</h4>
				<ol type="A">
					<li v-for="(optionItem, index_option) in question.options" :key="index_option">
					<label>
						<input type="radio" name="answer"/>
						{{ optionItem.content }}
					</label>
					</li>
				</ol>
		  </div>
	  </div>
    </div>


    <!-- <div class="btns" v-if="quizez && questionindex < quizez.length">
      <button class="btn prev" v-if="questionindex > 0" v-on:click="prev">
        Prev
      </button>
      <button class="btn next" v-if="questionindex < quizez.length - 1" v-on:click="next">
        Next
      </button>
	  <div class="rvsb" v-if="questionindex == quizez.length - 1">
		<button class="btn review" v-on:click="review">
			Review
		</button>
		<button class="btn submit" v-on:click="submit">
			Submit
		</button>
	  </div>
    </div> -->
  </div>
</template>

<script>
import axios from 'axios';
import RemainingTimer from './RemainingTimer'

export default {
	components:{
		RemainingTimer
	},
	name: "question",
	data: function() {
		return {
			questionindex: 0,
			parts: null,
			answers: null,
			currentPartIndex: 0,
		};
	},
	created(){
		axios.get('https://fivemanuman.gitlab.io/toeic/questions/new-questions.json')
		.then((response) => {
			if(response.data){
				this.$store.state.questionSize=response.questionSize;
				// this.answers=Array(this.quizez.parts).fill("")
				this.parts=response.data.parts;
			}
		})
	},
	methods: {
		// Go to next question
		next: function() {
			this.questionindex++;
		},
		// Go to previous question
		prev: function() {
			this.questionindex--;
		},
		review(){
			this.$router.push({
				name: 'Review'
			});
		},
		submit(){
			if(confirm("Do you really want to submit without reviewing?")){
				this.score();
				this.$router.push({
					name: 'Result'
				});
			}
		},
		score: function() {
			var total = 0;
			for (var i = 0; i < this.answers.length; i++) {
				if (this.answers[i] == this.quizez[i].correct_answer) {
					total += 1;
				}
			}
			this.$store.state.score=total;
		},
		answerQuestion(index_quiz, index_answer, answer){
			console.log("index_quiz: "+index_quiz+", index_answer: "+index_answer+", answer: "+answer)
		}
		// foo(e){
			
		// }
	},
	watch:{
		// answers(val,oldvar){
		// 	for (var i = 0; i < this.answers.length; i++) {
		// 		if(this.answers[i]==val){
		// 			console.log("i: "+i+", value: "+val);
		// 			break;
		// 		}
		// 	}
		// }
	}
};
</script>

<style>
#question {
  /* font-family: "Avenir", Helvetica, Arial, sans-serif; */
  font-family: 'Lato', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
.question{
	font-weight: bold;
	font-size: 20px;
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

audio{
	width: 40%;
}

</style>
