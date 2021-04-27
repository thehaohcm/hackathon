import Vue from 'vue'
import Router from 'vue-router'
import Welcome from '@/components/Welcome'
import CreateQuestion from '@/components/CreateQuestion'

Vue.use(Router)

export default new Router({
	mode: 'history',
	routes: [
		{
			path: '/',
			name: 'Welcome',
			component: Welcome
		},
		{
			path: '/create-question',
			name: 'CreateQuestion',
			component: CreateQuestion
		},
	]
})
