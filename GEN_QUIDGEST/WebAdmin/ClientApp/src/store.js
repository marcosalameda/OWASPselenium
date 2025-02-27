import { createStore } from 'vuex'

const store = createStore({
  state: {
    currentApp: '',
    currentYear: '',
    multiYearStatus: false, // True if the application has more than one data system, false otherwise
    currentLanguage: ''
  },
  mutations: {
    SET_APP: function (state, newValue) {
      state.currentApp = newValue;
    },
    SET_YEAR: function (state, newValue) {
      state.currentYear = newValue;
    },
    SET_MULTIYEARSTATUS: function (state, newValue) {
      state.multiYearStatus = newValue;
    },
    SET_LANGUAGE: function (state, newValue) {
      state.currentLanguage = newValue;
    }
  },
  actions: {
    changeApp: function (context, newValue) {
        context.commit("SET_APP", newValue);
    },
    changeYear: function (context, newValue) {
        context.commit("SET_YEAR", newValue);
    },
    changeMultiYearStatus: function (context, newValue) {
      context.commit("SET_MULTIYEARSTATUS", newValue);
    },
    changeLanguage: function (context, newValue) {
        context.commit("SET_LANGUAGE", newValue);
    }
  },
  getters: {
    App: state => state.currentApp,
    Year: state => state.currentYear,
    MultiYearStatus: state => state.multiYearStatus,
    Language: state => state.currentLanguage
  }
});

export default store;