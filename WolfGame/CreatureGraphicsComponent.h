#pragma once

ref class CreatureGraphicsComponent : WolfEngine::Entity::ICreatureGraphicsComponent {
public:
	virtual void Render(WolfEngine::Entity::Creature^);
	virtual void Update(WolfEngine::Entity::Creature^);
};

