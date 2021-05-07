<template>
	<div class="result">
		<h1>Result</h1>
	  
		<div class="panel">
			<div>Name: {{name}}</div>
			<div>Email: {{email}}</div>
			<div>Score: {{score}} / {{questionSize}}</div>
			<div>You will be received an email including your score and a result. Please check out your email inbox</div>
		</div>
		<div class="panel_btn">
			<button v-on:click="exit">{{msgBtn}}</button>
		</div>
  	</div>
</template>

<script>
export default {
	data: function() {
		return {
			name: this.$store.state.name,
			email: this.$store.state.email,
			score: this.$store.state.score,
			questionSize: this.$store.state.questionSize,
			msgBtn: "Exit",
		};
	},
	methods:{
		exit(){
			console.log("isClose: "+this.isClose);
			this.$router.push({
				name: 'Finished',
				query: { is_closed: this.$store.state.is_closed}, 
			});
		}
	}
};
</script>

<style scoped>
h1 {
  font-weight: normal;
}
.header{
	position: absolute;
  	left: 0;
  	top: 0;
  	width: 100%;
  	background-color:rgb(119, 176, 195);
  	color: rgb(68, 67, 67);
  	text-align: center;
}
</style>