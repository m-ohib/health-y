<script setup>
// US 4 og 5: Mine gåture, nyeste først. Ret og slet.
// TODO: Hent ture med getWalks() i onMounted.
// TODO: Vis dato, minutter, skridt og note for hver tur.
//       Skridt: vis walk.steps, eller "ca. {{ walk.estimatedSteps }}" når steps er null (US 13).
// TODO: Slet: spørg først "Er du sikker på, at du vil slette turen?" (US 5).
// TIP: Undgå window.confirm. Lav din egen dialog med store knapper ("Ja, slet" / "Nej, behold").
// TIP: Vis datoen på dansk: new Date(walk.date).toLocaleDateString('da-DK', { weekday: 'long', day: 'numeric', month: 'long' }).
</script>

<template>
  <main>
    <h1>Mine gåture</h1>
    <!-- TODO: <ul> med en <li> per tur -->
  </main>
</template>
