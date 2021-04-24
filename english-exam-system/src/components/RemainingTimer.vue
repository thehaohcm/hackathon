<template>
	<div>
		<div class="title-name">{{name}} [{{email}}]</div>
		<div class="cntdwn-pnl">
			Remaining Time: {{timerText}}
		</div>
	</div>
</template>

<script>
export default {
	data: function() {
		return {
			timerCount: 7200,
			timerText: '',
			name:this.$store.state.name,
			email:this.$store.state.email
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

					this.$router.push({
						name: 'Result'
					});
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
.title-name{
	text-align: right;
	font-weight: bold;
	color: rgb(92, 24, 148);
}
</style>