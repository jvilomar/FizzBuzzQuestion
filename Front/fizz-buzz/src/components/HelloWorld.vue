<template>
  <v-container>
    <v-row class="text-center">
      <v-col cols="12">
        <span>WillDom Tech Test - Jose Manuel Vilomar</span>
      </v-col>
      <v-col cols="6">
        <v-row >
          <v-text-field
            v-model="input"
            label="Fizz Buzz Number"
            outlined
          ></v-text-field>
          <v-divider  />
          <v-btn color="primary" 
                 @click="getWordList()">
            Start
          </v-btn>
        </v-row>
        <v-row v-for="(word, i) in wordList"
            :key="i">
          <span 
            :style="wordColor(i)"
            class="subheading mx-3">
            {{ word }}
          </span> <br >
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  import axios from 'axios'

  const api = axios.create({
    baseURL: 'https://localhost:44382/api/',
    headers: {
      'Content-Type': 'application/json'
    }
  })

  export default {
    name: 'HelloWorld',

    data: () => ({
      wordList: [],
      input: 0
    }),

    methods: {
      getWordList() {
        api.get(`/FizzBuzz`, {params: {input : this.input}})
          .then(response => {
            this.wordList = response.data
          })
          .catch(error => {
            console.log(error)
          })
      },
      wordColor: function(index){
          let color = "Primary"
          if(this.wordList[index] === "Fizz") { color = "blue" }
          if(this.wordList[index] === "Buzz") { color = "green" }
          if(this.wordList[index] === "Jazz") { color = "red" }
          if(this.wordList[index] === "FizzBuzz") { color = "#ff00ff" }
          if(this.wordList[index] === "FizzJazz") { color = "brown" }

          return { color : color}
        }
    },
    mounted() {
    },
  }
</script>
