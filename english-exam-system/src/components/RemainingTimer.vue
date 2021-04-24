<template>
	<div class="cntdwn-pnl">
		Remaining Time: {{timerText}}
	</div>
</template>

<script>
export default {
	name: "question",
	data: function() {
		return {
			timerCount: 7200,
			timerText: '',
		};
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
.cntdwn-pnl{
	font-size: 20px;
	color: rgb(133, 42, 42);
	font-weight: bold;
	text-align: right;
}
</style>