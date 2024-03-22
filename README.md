# UPsiJam4

## Entity relationship

![prefab](img/PrefabsScript.png)

![prefab](img/Prefabs.png)


## Milestones

### Priorité 0: Proof of concept

```mermaid
graph LR;
    B[FMod]
    B -->C[Pathfinding, Tag, layers]
    C --> Caméra_Placement_texture[Caméra, Placement plus texture]
```

1. FMod
2. Pathfinding, Tag, layers
3. Caméra, Placement plus texture  

### Priorité 1: Prototype V1

```mermaid
graph LR;
    A[Priorité 1: Prototype V1] -->|Map V1| B[Porte]
    A -->|Map V1| C[Pathfinding]
    A -->|Map V1| D[Colisison]
    A -->|Player| E[Player, Controller, Intercation, etc...]
```

1. Map V1
   1. Porte
   2. Pathfinding
   3. Colisison
2. Player, Controller, Intercation, etc...

### Priorité 2: Prototype complet

```mermaid
graph LR;
    A[Priorité 2: Prototype complet] -->|Pièges| B[Pièges, Controller]
    A -->|Post processing| C[Post processing, Shader]
    A -->|Map Finale| D[Map Finale]
    A -->|Minimap| E[Minimap, pièce, entity, controller]
    A -->|Jour, Nuit| F[Jour, Nuit]
    A -->|Argent, UI| G[Argent, UI]
    A -->|Finalisation sonore| H[Finalisation sonore]
```

1. Pièges, Controller
2. Post processing, Shader
3. Map Finale
4. Minimap, pièce, entity, controller
5. Jour, Nuit
6. Argent, UI
7. Finalisation sonore

