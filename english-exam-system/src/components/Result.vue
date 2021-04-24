<template>
	<div class="review">
		<h1>Result</h1>
	  
		<div class="panel">
			<div>Name: {{name}}</div>
			<div>Email: {{email}}</div>
			<div>Score: {{score}}</div>
			<div>You will be received an email including your score and a result. Please check out your email inbox</div>
		</div>
  	</div>
</template>

<script>
export default {
	name: "question",
	data: function() {
		return {
			name: this.$store.state.name,
			email: this.$store.state.email
		};
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