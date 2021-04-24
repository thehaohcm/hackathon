import Vuex from 'vuex';
import Vue from 'vue';

Vue.use(Vuex);

export default new Vuex.Store({
	state:{
		name: 'Hao Nguyen',
		email: 'thehaohcm@yahoo.com.vn',
		timeCount: 10,

		questions: [
			{
			  category: "Part V: Incomplete Sentences",
			  type: "multiple",
			  difficulty: "easy",
			  question: "Departmental restructuring will be discussed at the ____ monthly meeting",
			  correct_answer: "next",
			  incorrect_answers: [
				"next",
				"always",
				"soon",
				"like"
			  ]
			},
			{
			  category: "Part V: Incomplete Sentences",
			  type: "multiple",
			  difficulty: "medium",
			  question: "To keep ____ park beautiful, please place your nonrecyclables in the available trash cans",
			  correct_answer: "our",
			  incorrect_answers: ["our", "we", "us", "ours"]
			},
			{
			  category: "Part V: Incomplete Sentences",
			  type: "multiple",
			  difficulty: "easy",
			  question: "Mr. Hardin ____ additional images of the office building he is interested in leasing",
			  correct_answer: "requested",
			  incorrect_answers: ["informed", "asked", "advised", "requested"]
			},
			{
			  category: "Part V: Incomplete Sentences",
			  type: "multiple",
			  difficulty: "hard",
			  question: "A team of agricultural experts will be brought ____ to try to improve crop harvests",
			  correct_answer: "together",
			  incorrect_answers: ["because", "either", "between", "together"]
			},
			{
			  category: "Part V: Incomplete Sentences",
			  type: "multiple",
			  difficulty: "medium",
			  question: "The board of Galaxipharm ____ Mr. Kwon's successor at yesterday's meeting",
			  correct_answer: "granted",
			  incorrect_answers: ["named", "granted", "founded", "proved"]
			},
			{
			  category: "Part V: Incomplete Sentences",
			  type: "multiple",
			  difficulty: "medium",
			  question: "If your parking permit is damaged, bring it to the entrance station for a ____",
			  correct_answer: "replacement",
			  incorrect_answers: [
				"replacement",
				"replacing",
				"replace",
				"replaces"
			  ]
			},
			{
			  category: "Part V: Incomplete Sentences",
			  type: "multiple",
			  difficulty: "medium",
			  question: "Mr. Ahmad decided to reserve a private room for the awards dinner ____ the restaurant was noisy",
			  correct_answer: "in case",
			  incorrect_answers: ["rather than", "in case", "such as", "unless"]
			},
			{
			  category: "Part V: Incomplete Sentences",
			  type: "boolean",
			  difficulty: "medium",
			  question: "Ms. Jones has provided a ____ estimate of the costs of expanding distribution statewide",
			  correct_answer: "conserve",
			  incorrect_answers: ["conserve", "conserves","conservative","conservatively"]
			},
			{
			  category: "Part V: Incomplete Sentences",
			  type: "multiple",
			  difficulty: "easy",
			  question: "Each quarter, Acaba Exports sets ____ sales goals for its staff",
			  correct_answer: "realistic",
			  incorrect_answers: [
				"compact",
				"wealthy",
				"faithful",
				"realistic"
			  ]
			},
			{
			  category: "Part V: Incomplete Sentences",
			  type: "multiple",
			  difficulty: "medium",
			  question: "Ms. Garcia was delighted to receive ____ that her company soon will be featured in the In Town Times magazine",
			  correct_answer: "notification",
			  incorrect_answers: ["notify", "notifycation",  "notifying",  "notifies"]
			}
		  ],
	},

	getters:{

	},

	mutations:{

	},

	actions:{

	}
})