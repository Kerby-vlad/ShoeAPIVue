<template>
  <v-dialog
      v-model="dialog"
      width="600"
  >
    <template v-slot:activator="{ on, attrs }">
      <v-btn
          color="primary"
          outlined
          plain
          v-bind="attrs"
          v-on="on"
          class="mb-10"
      >
        Create New {{ model.ModelName }}
      </v-btn>
    </template>

    <v-card>
      <v-card-title>
        <span class="text-h5">{{ model.ModelName }} Creation</span>

        <v-spacer></v-spacer>

        <v-btn
            color="black"
            icon
            @click="dialog = false">
          <v-icon>mdi-close</v-icon>
        </v-btn>
      </v-card-title>

      <v-card-text>
        <brand-form v-if="model.ModelName === `Brand`" :brand="model"></brand-form>
        <type-form v-if="model.ModelName === `Type`" :type="model"></type-form>
        <shoe-form v-if="model.ModelName === 'Shoe'" :shoe="model" :brands="brands"></shoe-form>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
            color="blue darken-1"
            text
            @click="dialog = false">
          Close
        </v-btn>
        <v-btn
            color="blue darken-1"
            text
            @click="Create">
          Create
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import {eventBus} from "../../main";
import BrandForm from "./brand-form";
import ShoeForm from "./shoe-form";
import TypeForm from "./type-form";

export default {
  components: {TypeForm, ShoeForm, BrandForm},
  props: {
    model: Object,
    brands: {
      required: false,
      type: Array
    }
  },
  data() {
    return {
      dialog: false,
      responseFine: true,
      snackBar: false,
      models: {
        Name: "",
        POST: null
      }
    }
  },
  methods: {
    Create() {
      this.model.POST(this.$store.getters.CONFIG_HEADER)
          .then((response) => {
            let status = response.status;
            if (status >= 200 && status < 300) {
              this.$store.dispatch(`UPDATE_${this.model.ModelName.toUpperCase()}S`);
              eventBus.$emit('showNotification', {responseFine: "Fine", snackBar: true, text: "Fine"});
            }
            else{
              eventBus.$emit('showNotification', {responseFine: "Error", snackBar: true, text: response.data})
            }
          });

    }
  }
}
</script>