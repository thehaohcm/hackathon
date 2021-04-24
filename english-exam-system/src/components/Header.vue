<template>
	<div class="header">
	  <h1>English Examination System</h1>
	  <div class="cntdwn-pnl">
		  Remaining Time: {{timerText}}
	  </div>
  	</div>
</template>

<script>
export default {
	name: "question",
	data: function() {
		return {
			timerCount : 7200,
			timerText: '',
		};
	},
	methods: {
		
	},
	computed: {
	},
	watch: {
		timerCount: {
			handler(value) {
				if (value > 0) {
				setTimeout(() => {
					this.timerCount--;
					this.timerText = new Date(this.timerCount * 1000).toISOString().substr(11, 8);
				}, 1000);
				}else if(value==0){
					console.log("a feature that auto submit when over time is not implemented yet");
				}
			},
			immediate: true 
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