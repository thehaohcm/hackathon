<template>
	<div class="finished">
		<p hidden>{{timeCount}}</p>
  	</div>
</template>

<script>
export default {
	name: "question",
	data: function() {
		return {
			timerCount: 1,
		};
	},
	watch: {
        timerCount: {
            handler(value) {
                if (value > 0) {
                setTimeout(() => {
                    this.timerCount--;
					this.timerCount=('0'+this.timerCount).slice(-2);
                }, 1000);
                }else if(value==0){
					this.isHidden=true;
					this.isShown=true;
					this.$router.push({
						name: 'InputInfo'
					});
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