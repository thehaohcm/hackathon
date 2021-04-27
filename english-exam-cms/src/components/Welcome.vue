<template>
  <div class="welcome">
    <h2>Hello and welcome to {{msg}}</h2>
	<div class="info">
		<div class="lbl">
			<label>Name:</label><label>{{name}}</label>
		</div>
		<div class="lbl">
			<label>Email:</label><label>{{email}}</label>
		</div>
	</div>
	<div v-if="!isHidden">
		<h3>An examination will be started automatically after: </h3>
		<div class="cntdwn-pnl">
			{{timerCount}}
		</div>
		second(s)
	</div>
	
	<div v-if="isShown" style="margin-top: 30px;">
		If the application cannot automatically redirect, please click
		<router-link class="nav-link" to="/questions"><b>here to start</b></router-link>
	</div>
	<h4>Good luck and have a good day</h4>
  </div>
</template>

<script>
export default {
	name: 'HelloWorld',
	data () {
		return {
			msg: "a S3Corp's Annual English Examination",
			name: this.$store.state.name,
			email: this.$store.state.email,
			timerCount: this.$store.state.timeCount,
			isHidden: false,
			isShown: false
		}
	},
	created:function(){
		var _name=this.$route.query.name;
		var _email=this.$route.query.email;
		if(_name&&_email&&this.validateEmail(_email)){
			this.$store.state.name=_name;
			this.$store.state.email=_email;
			this.name=_name;
			this.email=_email;
		}else if(!this.$store.state.name||!this.$store.state.email){
			this.$router.push({
				name: 'CreateQuestion'
			});
		}
	},
	methods:{
		validateEmail(email) {
			const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
			return re.test(String(email).toLowerCase());
		}
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
						name: 'Question'
					});
				}
            },
            immediate: true 
        }
	}
}
</script>

<style scoped>
h1, h2, h3, h4 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
.welcome{
	text-align: center;
}
.info{
	border-style: dashed;
	text-align: left;
	top: 50%;
	left: 38%;
	margin-left: 35%;
	margin-right:32%;
	background-color: lightgray;
}
label{
	padding: 10pt;
	font-size: 15pt;
	margin: 10pt;
}
.lbl{
	margin:10pt;
}
.cntdwn-pnl{
	font-size: 50pt;
}
.hiden-btn{
	display: none;
}
</style>
