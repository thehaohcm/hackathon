<template>
	<div class="inputInfo">
		<flash-message transitionIn="animated swing" class="myCustomClass"></flash-message>
		<div class="panel">
			<div class="lbl">
				<label>Name:</label><br/>
				<input v-model="name"/>
			</div>
			<div class="lbl">
				<label>Email:</label><br/>
				<input v-model="email"/>
			</div>
			<div class="submit-btn">
				<button v-on:click="sendSubmit">Submit</button>
			</div>
		</div>
  	</div>
</template>

<script>
export default {
	data: function() {
		return {
			name: "",
			email: ""
		};
	},
	methods:{
		sendSubmit(){
			if(this.name!=='' && this.email!==''){
				if(this.validateEmail(this.email)){
					this.$store.state.name=this.name;
					this.$store.state.email=this.email;
					this.$router.push({
						name: 'Welcome'
					});
				}else{
					//alert("The email address is invalid.\nPlease input again","Invalid email");
					this.flash('The email address is invalid.\nPlease input again', 'warning', {
						timeout: 2000,
						// beforeDestroy() {
						// 	alert('oh no, not again!');
						// }
					});

				}
			}
		},
		validateEmail(email) {
			const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
			return re.test(String(email).toLowerCase());
		}
	}
}
</script>


<style scoped>
h1 {
  font-weight: normal;
}
.lbl{
	margin: 10pt;
}
</style>