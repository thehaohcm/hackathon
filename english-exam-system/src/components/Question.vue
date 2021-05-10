<template>
  	<div id="question">
		<RemainingTimer />
		<div>
			<h1>Part {{currentPart.partNumber}}: {{ currentPart.partName }}</h1>
			<br/>

			<div v-for="(questionGroupContent, questionGroupContentIndex) in currentQuestionGroup.questionGroupContents" :key="questionGroupContentIndex+'questionGroupContent'">
				<div v-if="questionGroupContent.type=='audio'">
					<audio controls :src="questionGroupContent.source" type="audio/mp3" controlsList="nodownload"></audio>
					<br />
				</div>
				<div v-if="questionGroupContent.type=='image'">
					<img :src="questionGroupContent.source"/>
					<br />
				</div>
				<div v-if="questionGroupContent.type=='text'">
					<p>{{questionGroupContent.source}}</p>
					<br />
				</div>
			</div>
				<div v-for="(questionContent, questionContentIndex) in currentQuestion.questionContents" :key="questionContentIndex+'questionContent'">
					<div v-if="questionContent.type=='audio'">
						<audio controls :src="questionContent.source" type="audio/mp3" controlsList="nodownload"></audio>
						<br />
					</div>
					<div v-if="questionContent.type=='image'">
						<img :src="questionContent.source"/>
						<br />
					</div>
					<div v-if="questionContent.type=='text'">
						<p>{{questionContent.source}}</p>
						<br />
					</div>
				</div>
				<h4 class="question">Question {{currentQuestion.id}}.&emsp;{{currentQuestion.question}}</h4>
				<ol type="A">
					<li v-for="(questionOptionItem, questionOptionIndex) in currentQuestion.options" :key="questionOptionIndex+'questionOptionItem'">
					<label>
						<input type="radio" name="answer"/>
						{{ questionOptionItem.content }}
					</label>
					</li>
				</ol>
		</div>

		<div class="btns">
			<button class="btn btn-outline-info btn-lg prev" v-on:click="prev">
				Prev
			</button>
			<button class="btn btn-outline-info btn-lg next" v-on:click="next">
				Next
			</button>
			<div class="rvsb">
				<button class="btn btn-secondary btn-lg review" v-on:click="review">
					Review
				</button>
				<button class="btn btn-primary btn-lg active" v-on:click="submit">
					Submit
				</button>
			</div>
		</div>
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
			currentQuestionGroupIndex: 0,
			currentQuestionIndex: 0,

			currentPart: null,
			currentQuestionGroup: null,
			currentQuestion: null,
		};
	},
	created: function(){
		if(!this.$store.state.name || !this.$store.state.email){
			this.$router.push({
				name: 'InputInfo'
			});
		}
			
		axios.get('https://fivemanuman.gitlab.io/toeic/questions/new-questions.json')
		.then((response) => {
			if(response.data){
				this.$store.state.questionSize=response.questionSize;
				// this.answers=Array(this.quizez.parts).fill("")
				this.parts=response.data.parts;

				this.currentPart=this.parts[this.currentPartIndex];
				this.currentQuestionGroup=this.currentPart.questionGroups[this.currentQuestionGroupIndex];
				this.currentQuestion=this.currentQuestionGroup.questions[this.currentQuestionIndex];
				
			}
		})
	},
	methods: {
		// Go to next question
		next: function() {
			if(this.currentQuestionIndex>=0 && this.currentQuestionIndex<this.currentQuestionGroup.questions.length-1){
				this.currentQuestionIndex++;
				this.currentQuestion=this.currentQuestionGroup.questions[this.currentQuestionIndex];
			}else if(this.currentQuestionGroupIndex>=0 && this.currentQuestionGroupIndex<this.currentPart.questionGroups.length-1){
				this.currentQuestionGroupIndex++;
				this.currentQuestionGroup=this.currentPart.questionGroups[this.currentQuestionGroupIndex];

				this.currentQuestionIndex=0;
				this.currentQuestion=this.currentQuestionGroup.questions[this.currentQuestionIndex];
			}else if(this.currentPartIndex>=0 && this.currentPartIndex<this.parts.length-1){
				this.currentPartIndex++;
				this.currentPart=this.parts[this.currentPartIndex];

				this.currentQuestionGroupIndex=0;
				this.currentQuestionGroup=this.currentPart.questionGroups[this.currentQuestionGroupIndex];

				this.currentQuestionIndex=0;
				this.currentQuestion=this.currentQuestionGroup.questions[this.currentQuestionIndex];
			}
		},
		// Go to previous question
		prev: function() {
			if(this.currentQuestionIndex>0 && this.currentQuestionIndex<this.currentQuestionGroup.questions.length){
				this.currentQuestionIndex--;
				this.currentQuestion=this.currentQuestionGroup.questions[this.currentQuestionIndex];
			}else if(this.currentQuestionGroupIndex>0 && this.currentQuestionGroupIndex<this.currentPart.questionGroups.length){
				this.currentQuestionGroupIndex--;
				this.currentQuestionGroup=this.currentPart.questionGroups[this.currentQuestionGroupIndex];

				this.currentQuestionIndex=this.currentQuestionGroup.questions.length-1;
				this.currentQuestion=this.currentQuestionGroup.questions[this.currentQuestionIndex];
			}else if(this.currentPartIndex>=0 && this.currentPartIndex<this.parts.length-1){
				this.currentPartIndex--;
				this.currentPart=this.parts[this.currentPartIndex];

				this.currentQuestionGroupIndex=this.currentPart.questionGroups.length-1;
				this.currentQuestionGroup=this.currentPart.questionGroups[this.currentQuestionGroupIndex];

				this.currentQuestionIndex=this.currentQuestionGroup.questions.length-1;
				this.currentQuestion=this.currentQuestionGroup.questions[this.currentQuestionIndex];
			}
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
		},
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
	},
	mounted(){

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
