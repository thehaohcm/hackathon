import Vuex from 'vuex';
import Vue from 'vue';
import VueFlashMessage from 'vue-flash-message';

Vue.use(Vuex);
Vue.use(VueFlashMessage);
require('vue-flash-message/dist/vue-flash-message.min.css');

export default new Vuex.Store({
	state:{
		// name: 'Hao Nguyen',
		// email: 'thehaohcm@yahoo.com.vn',
		name: '',
		email: '',
		timeCount: 10,
	},

	getters:{

	},

	mutations:{

	},

	actions:{

	}
})